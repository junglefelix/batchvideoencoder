using BatchVideoEncoder.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchVideoEncoder.Helpers
{
    public static class MediaProcessingHelper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public static string workingDir;
        public static bool isRunHidden;

        public static List<StreamInfo> ParseStreams(string filePath)
        {
            var streams = new List<StreamInfo>();
            if (!System.IO.File.Exists(filePath)) return streams;

            try
            {
                var movie = new MediaInfoNET.MediaFile(filePath);

                // Video streams
                for (int i = 0; i < movie.Video.Count; i++)
                {
                    var v = movie.Video[i];
                    string lang = v.Properties.ContainsKey("Language") ? v.Properties["Language"].ToString() : string.Empty;
                    streams.Add(new StreamInfo
                    {
                        StreamIndex   = v.StreamIndex,
                        StreamType    = StreamType.Video,
                        Codec         = v.FormatID ?? v.Format ?? string.Empty,
                        Language      = lang,
                        Channels      = string.Empty,
                        Include       = true
                    });
                }

                // Audio streams
                for (int i = 0; i < movie.Audio.Count; i++)
                {
                    var a = movie.Audio[i];
                    string lang = a.Properties.ContainsKey("Language") ? a.Properties["Language"].ToString() : string.Empty;
                    string channels = a.Channels > 0 ? a.Channels.ToString() : string.Empty;
                    streams.Add(new StreamInfo
                    {
                        StreamIndex   = a.StreamIndex,
                        StreamType    = StreamType.Audio,
                        Codec         = a.FormatID ?? a.Format ?? string.Empty,
                        Language      = lang,
                        Channels      = channels,
                        Include       = true,
                        IsPrimary     = (i == 0)
                    });
                }

                // Subtitle (Text) streams
                for (int i = 0; i < movie.Text.Count; i++)
                {
                    var t = movie.Text[i];
                    string lang = t.Language ?? string.Empty;
                    if (string.IsNullOrEmpty(lang) && t.Properties.ContainsKey("Language"))
                        lang = t.Properties["Language"].ToString();
                    streams.Add(new StreamInfo
                    {
                        StreamIndex   = t.StreamIndex,
                        StreamType    = StreamType.Subtitle,
                        Codec         = t.FormatID ?? t.Format ?? string.Empty,
                        Language      = lang,
                        Channels      = string.Empty,
                        Include       = true,
                        IsPrimary     = (i == 0)
                    });
                }

                // Other streams (Menu, Data, etc.)
                foreach (var s in movie.AllStreams)
                {
                    if (s.StreamType == "Video" || s.StreamType == "Audio" || s.StreamType == "Text") continue;
                    string lang = s.Properties.ContainsKey("Language") ? s.Properties["Language"].ToString() : string.Empty;
                    streams.Add(new StreamInfo
                    {
                        StreamIndex   = s.StreamIndex,
                        StreamType    = StreamType.Other,
                        Codec         = s.FormatID ?? s.Format ?? string.Empty,
                        Language      = lang,
                        Channels      = string.Empty,
                        Include       = true
                    });
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error parsing streams for file {0}: {1}", filePath, ex.ToString());
            }

            return streams;
        }





        public static bool encodeVideoFFMpeg(MovieEntry dbEntry,  Action<string, bool> callBack)
        {
            logger.Info("Entered encodeVideoFFMpeg()");
            var srcFileName = dbEntry.fullFilePath;
            var crf = dbEntry.crf;
            var nr = dbEntry.nr;
            var preset = dbEntry.presetStr;
            

            #region resize and noise filtering handling
            // resize and noise filtering handling
            var filtersStr = string.Empty;
            var resizeStr = dbEntry.GetResizeStrFFMPEG(); // will be empty if no resize
            if (string.IsNullOrEmpty(resizeStr)) // NO resize
            {
                if (dbEntry.useNoiseFilter) filtersStr = " -filter:v " + dbEntry.DenoiseFilterStr; // filter only
                else filtersStr = " ";
            }
            else // with resize
            {
                if (dbEntry.useNoiseFilter) filtersStr = " -filter:v " + dbEntry.DenoiseFilterStr + "," + resizeStr + " ";
                else filtersStr = "-vf " + resizeStr + " ";    // resize only
            }
            logger.Info("Resize and filter string is:" + filtersStr);
            #endregion
            #region Output File Name
            if (File.Exists(dbEntry.dstEncodedFile))
            {
                try
                {
                    File.Delete(dbEntry.dstEncodedFile);
                }
                catch (Exception ex)
                {
                    logger.Error("Error!! exception occurred when deleting file= " + dbEntry.dstEncodedFile);
                    logger.Error("Exception= " + ex.ToString());
                    return false;
                }
            }
            logger.Info("Output filename is going to be = " + dbEntry.dstEncodedFile);
            #endregion

            // Build codec + CRF arguments:
            // x264/x265 pass CRF via encoder params string; AV1 (libaom-av1) uses -crf directly.
            string vCodecAndCrfStr;
            switch (dbEntry.videoCodec)
            {
                case VideoCodec.X264:
                    vCodecAndCrfStr = " libx264 -x264-params crf=" + crf;
                    break;
                case VideoCodec.AV1:
                    vCodecAndCrfStr = " libaom-av1 -crf " + crf + " -b:v 0";
                    break;
                default: // X265
                    vCodecAndCrfStr = " hevc -x265-params crf=" + crf;
                    break;
            }

            // Build audio encoding arguments using libopus
            string audioArgs;
            switch (dbEntry.opusChannelMode)
            {
                case OpusChannelMode.CopyAllStreams:
                    audioArgs = " -map 0 -c:a copy";
                    break;
                case OpusChannelMode.KeepSourceChannels:
                    audioArgs = " -map 0 -c:a libopus -b:a " + dbEntry.opusBitrate + "k";
                    break;
                default: // ConvertToStereo
                    audioArgs = " -map 0 -c:a libopus -ac 2 -b:a " + dbEntry.opusBitrate + "k";
                    break;
            }

            string cli_path = @"start ""encode"" /b /low /wait """ + workingDir + @"\tools\ffmpeg.exe"" -i " +
                "\"" + srcFileName + "\"" + audioArgs + filtersStr + " -preset " + preset +
                " -map 0:s? -c:s copy" + " -c:v " + vCodecAndCrfStr + " \"" + dbEntry.dstEncodedFile + "\"";
            // copy subtitles: -map 0:s -c copy
            logger.Info("FFMpeg video encoding and mux command: {0}{1}", Environment.NewLine, cli_path);
            ProcessHelper.RunProcessWithCallback("cmd", "/c " + cli_path, callBack, Path.Combine(workingDir, "Tools"), isRunHidden);
            logger.Info("Encode and Mux command process finished.");
            logger.Info("About to check if output file was created...");
            if (File.Exists(dbEntry.dstEncodedFile))
            {
                logger.Info(" Encoded File exists: " + dbEntry.dstEncodedFile);
                return true;
            }
            else
            {
                logger.Error("Targer file does not exist: " + dbEntry.dstEncodedFile);
                return false;
            }
        }

       

    
    }
}
