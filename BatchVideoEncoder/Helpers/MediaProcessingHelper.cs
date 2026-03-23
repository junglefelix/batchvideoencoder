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

            string vCodecStr = dbEntry.useX264 ? " libx264 -x264-params " : " hevc -x265-params ";
            string cli_path = string.Empty;
            
            switch (dbEntry.audioMode)
            {
                case AudioMode.Encode:
                    cli_path = @"start ""encode"" /b /low /wait """ +                                       //set low priority
                       workingDir + @"\tools\ffmpeg.exe"" -i " + "\"" + dbEntry.encodedAacFile + "\"" +   //Input1 - aac Audio
                       " -i " + " \"" + srcFileName + "\"" + " -map 0:0 -map 1:0 -acodec copy " + filtersStr + " -preset " + preset +
                       " -map 1:s? -c copy " + " -c:v " + vCodecStr + " crf=" + crf + " \"" + dbEntry.dstEncodedFile + "\"";
                    break;
                case AudioMode.Copy:
                    cli_path = @"start ""encode"" /b /low /wait """ + workingDir + @"\tools\ffmpeg.exe"" -i " +
                       " \"" + srcFileName + "\"" + " -c:a copy -map 0 " + filtersStr + " -preset " + preset+ 
                     " -c:v " + vCodecStr + " crf=" + crf + " \"" + dbEntry.dstEncodedFile + "\"";
                    break;
                case AudioMode.Disable:
                    cli_path = @"start ""encode"" /b /low /wait """ + workingDir + @"\tools\ffmpeg.exe"" -i " + 
                       " \"" + srcFileName + "\"" + " -an " + filtersStr + " -preset " + preset   + " -map 0:s? -c copy " +
                      " -map 0:v -c:v " + vCodecStr + " crf=" + crf + " \"" + dbEntry.dstEncodedFile + "\"";
                    break;
                default:
                    break;
            }
            // copy subtitles: -map 0:s -c copy
            logger.Info("FFMpeg video encoding and mux command: {0}{1}", Environment.NewLine, cli_path);
            ProcessHelper.RunProcessWithCallback("cmd", "/c " + cli_path, callBack, Path.Combine(workingDir, "Tools"), isRunHidden);
            logger.Info("Encode and Mux command process finished.");
            logger.Info("will delete temp audio files...");
            if (File.Exists(dbEntry.encodedAacFile)) File.Delete(dbEntry.encodedAacFile);
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

       

        public static bool encodeAudio(MovieEntry dbEntry)
        {
            logger.Info( "Entered encodeAudio()");
            var aQuality = dbEntry.aQuality.ToString();
            // ffmpeg -i source.avi -acodec pcm_s32le -ac 2 -f wav - | neroAacEnc -if - -q 0.24 -ignorelength -of out.mp4
            string cli_path = @"start ""encode"" /b /low /wait """ +                                      
                   workingDir + @"\tools\ffmpeg.exe"" -i " + "\"" + dbEntry.fullFilePath + "\"" +
                   " -acodec pcm_s32le -ac 2 -f wav - | neroAacEnc -if - -q " + aQuality +
                   " -ignorelength -of \"" + dbEntry.encodedAacFile + "\"";

           logger.Info("Audio Encoding arguments: {0}", cli_path);
           logger.Info( "Working dir=" + workingDir);
            //Helper.run_CLI_tool2(cli_path,Path.Combine(workingDir, "Tools"),isRunHidden);
            var cmdOut =  ProcessHelper.runCliAppWithOutput("cmd", "/c " + cli_path, Path.Combine(workingDir, "Tools"), isRunHidden);
            logger.Info("Audio encode ouput is................:");
            logger.Info(cmdOut);
            logger.Info("About to check if output file was created...");
            if (File.Exists(dbEntry.encodedAacFile))
            {
                logger.Info("Encoded aac ile exists, name=" + dbEntry.encodedAacFile);
                return true;

            }
            else
            {
                logger.Error( "!! Error !! File does not exist, name=" + dbEntry.encodedAacFile);
                return false;
            }
        }

    
    }
}
