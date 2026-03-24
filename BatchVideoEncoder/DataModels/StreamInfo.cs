using System;

namespace BatchVideoEncoder
{
    public enum StreamType { Video, Audio, Subtitle, Other }

    public class StreamInfo
    {
        public int StreamIndex { get; set; }
        public StreamType StreamType { get; set; }
        public string Codec { get; set; }
        public string Language { get; set; }
        public string Channels { get; set; }
        public string Bitrate { get; set; }
        public bool Include { get; set; }
        public bool IsPrimary { get; set; }

        public string StreamTypeLabel
        {
            get
            {
                switch (StreamType)
                {
                    case StreamType.Video:    return "Video";
                    case StreamType.Audio:    return "Audio";
                    case StreamType.Subtitle: return "Subtitle";
                    default:                  return "Other";
                }
            }
        }
    }
}
