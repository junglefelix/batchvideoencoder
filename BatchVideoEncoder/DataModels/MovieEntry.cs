using MediaInfoNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BatchVideoEncoder
{
    public  enum ResizeOption { NoResize,ResizeByPercent, LimitRes};
    public enum Preset { fast, medium, slow, slower, slowest };
    public enum VideoCodec { X264, X265, AV1 };

    public class MovieEntry
    {

        public MovieEntry()
        {

        }
        public MovieEntry(int _index, string _filePath)
        {
            index = _index;
            //origResStr = "err";
            durationStr = "err";
            vRate = -1;
            aCodec = "err";
            numOfAudioChannels = -1;
            aRate = -1;
            aSizeStr = "err";
            aStreams = -1;
            bitsPixelFrameStr = "err";
            fullFilePath = _filePath;
            fileNameOnly = Path.GetFileName(_filePath);
        useDefaultParams = true;
            videoCodec = VideoCodec.X265;
            useNoiseFilter = true;
            curPercentDone = 0.0;
            opusBitrate = 96;
            opusChannelMode = OpusChannelMode.ConvertToStereo;

        }
        public int index { get; set; }
        public string fullFilePath { get; set; }
        public string fileNameOnly { get; set; }
        public string durationStr { get; set; }
        public int vRate { get; set; }
        public string aCodec { get; set; }
        public int numOfAudioChannels { get; set; }
        public int aRate { get; set; }
        public string aSizeStr { get; set; }
        public double aSizeMB { get; set; }
        public string vSizeStr { get; set; }
        public double vSizeMB { get; set; }
        public int aStreams { get; set; }
        public string bitsPixelFrameStr { get; set; }
        public int totFrames { get; set; }
        public ResizeOption resize { get; set; }
        
        public int xRes { get; set; } // original src X resolution
        public int yRes { get; set; }  // original src Y resolution
        public int NewXRes { get; set; }
        public int NewYRes { get; set; }
        public int ResizePercentage { get; set; } // for <by Percentage> option only
        public int limitXres { get; set; } // for <limit resolution> option only
        public int limitYres { get; set; } // for <limit resolution> option only
        public double crf { get; set; }
        public double nr { get; set; }
        public Preset preset { get; set; }
        public string presetStr { get; set; }
        public bool useDefaultParams { get; set; } // if false - use default Encoding params.

        public VideoCodec videoCodec { get; set; }
        public bool useNoiseFilter { get; set; }
        public string DenoiseFilterName { get; set; }
        public string DenoiseFilterStr { get; set; }
        public string dstEncodedFile { get; set; }
        public double curPercentDone { get; set; }
        public DateTime TimeStartedEncoding { get; set; }
        public string encodedAacFile { get; set; }
        public int opusBitrate { get; set; }
        public OpusChannelMode opusChannelMode { get; set; }

        #region Properties

        public string origResStr
        {
            get
            {
                return xRes.ToString() + "x" + yRes.ToString();
            }
        }
        public string newResStr
        {
            get
            {
                return NewXRes.ToString() + "x" + NewYRes.ToString();
            }
        }
        public double inputRatio
        {
            get
            {
                return (double)xRes / (double)yRes;
            }
        }


        #endregion

        public string GetResizeStrFFMPEG()
        {
            // resizing in ffmpeg:     -vf scale=320:240
            if (resize == ResizeOption.NoResize) return string.Empty;
            else return "scale=" + NewXRes + ":" + NewYRes;
        }
        
        public void calculateNewRes()
        {
            switch (resize)
            {
                case ResizeOption.NoResize:
                    NewXRes = xRes;
                    NewYRes = yRes;
                    break;
                case ResizeOption.ResizeByPercent:
                    double newX = (double)xRes * (double)ResizePercentage / 100;
                    double newY = (double)yRes * (double)ResizePercentage / 100;
                    NewXRes = UiUpdateHelper.to_nearest_16(newX);
                    NewYRes = UiUpdateHelper.to_nearest_16(newY);
                    break;
                case ResizeOption.LimitRes:
                    double xScaleDownFactor, yScaleDownFactor;
                    if (xRes > limitXres || yRes > limitYres)
                    {
                        xScaleDownFactor = (double)xRes / (double)limitXres;
                        yScaleDownFactor = (double)yRes / (double)limitYres;
                        float maxScaleFactor = (float)Math.Max(xScaleDownFactor, yScaleDownFactor);
                        NewXRes = UiUpdateHelper.to_nearest_16((float)xRes / maxScaleFactor);
                        NewYRes = UiUpdateHelper.to_nearest_16((float)yRes / maxScaleFactor);
                    }
                    else
                    {
                        NewXRes = xRes;
                        NewYRes = yRes;
                    }
                        break;
                default:
                    break;
            }
            
        }
    }

    public enum OpusChannelMode
    {
        ConvertToStereo,
        KeepSourceChannels,
        CopyAllStreams
    }
}
