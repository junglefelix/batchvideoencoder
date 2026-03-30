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





        public static bool encodeVideoFFMpeg(MovieEntry dbEntry, Action<string, bool> callBack, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            
            string mappings = " -map 0:v:0" +  // default mapping for video stream (first video stream)
                " -map 0:a?" + // map all audio streams if exist, otherwise ignore audio streams
                " -map 0:s? "; // map all subtitle streams if exist, otherwise ignore subtitle streams


            string vCodecAndCrfStr;
            switch (dbEntry.videoCodec)
            {
                case VideoCodec.X264:
                    vCodecAndCrfStr = " -c:v libx264 -crf " + crf;
                    break;
                case VideoCodec.AV1:
                    vCodecAndCrfStr = " -c:v libsvtav1 -crf " + crf;
                    break;
                case VideoCodec.X265:
                    vCodecAndCrfStr = " -c:v libx265 -crf " + crf;
                    break;
                default:
                    vCodecAndCrfStr = " -c:v libsvtav1 -crf " + crf;
                    break;
            }

            // Build audio encoding arguments using libopus
            string audioArgs;
            switch (dbEntry.audioChannelMode)
            {
                case OpusChannelMode.CopyAllStreamsAsIs:
                    audioArgs = " -c:a copy";
                    break;
                default: // ConvertToStereo
                    audioArgs = " -c:a libopus -ac 2 -b:a " + dbEntry.opusBitrate + "k"; //-c:a libopus -ac 2 -b:a 96k
                    break;
            }

            string presetArg = (dbEntry.videoCodec == VideoCodec.AV1)
                ? " -preset " + GetAv1Preset(preset)
                : " -preset " + preset;

            // Build the ffmpeg argument string (no cmd/start wrapper so the process can be killed directly)
            string ffmpegArgs = "-i " +
                "\"" + srcFileName + "\"" + mappings + audioArgs + filtersStr + presetArg +
                vCodecAndCrfStr + " -c:s copy \"" + dbEntry.dstEncodedFile + "\"";

            logger.Info("FFMpeg video encoding and mux command: {0}{1}", Environment.NewLine, "ffmpeg " + ffmpegArgs);
            bool processExitedClean = ProcessHelper.RunProcessWithCallback("ffmpeg", ffmpegArgs, callBack, workingDir, isRunHidden, cancellationToken);
            logger.Info("Encode and Mux command process finished.");
            if (!processExitedClean)
            {
                logger.Error("FFMpeg exited with a non-zero exit code. Encoding failed.");
                return false;
            }
            logger.Info("About to check if output file was created...");
            if (File.Exists(dbEntry.dstEncodedFile))
            {
                var fileSize = new FileInfo(dbEntry.dstEncodedFile).Length;
                if (fileSize == 0)
                {
                    logger.Error("Output file is 0 bytes, encoding failed: " + dbEntry.dstEncodedFile);
                    try { File.Delete(dbEntry.dstEncodedFile); } catch { }
                    return false;
                }
                logger.Info("Encoded file exists and has size " + fileSize + " bytes: " + dbEntry.dstEncodedFile);
                return true;
            }
            else
            {
                logger.Error("Target file does not exist: " + dbEntry.dstEncodedFile);
                return false;
            }
        }

        /// <summary>
        /// Maps x265-style named presets to SVT-AV1 numeric presets (0=best/slowest, 13=fastest).
        /// </summary>
        private static string GetAv1Preset(string namedPreset)
        {
            switch ((namedPreset ?? string.Empty).ToLowerInvariant())
            {
                case "ultrafast":  return "12";
                case "superfast":  return "11";
                case "veryfast":   return "10";
                case "faster":     return "9";
                case "fast":       return "8";
                case "medium":     return "7";
                case "slow":       return "5";
                case "slower":     return "3";
                case "veryslow":   return "1";
                default:
                    int n;
                    return int.TryParse(namedPreset, out n) ? namedPreset : "7";
            }
        }

    
    }
}

