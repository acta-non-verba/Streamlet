using System;
using System.Collections.Generic;

namespace StreamletExperience
{
    public interface IStreamable
    {
        string Stream(string preferredContent);
    }

    public class StaticContentStreamer : IStreamable
    {

        public string Stream(string preferredContent)
        {
            return "Streaming web series - " + preferredContent;
        }
    }

    public class LiveStreamContentStreamer : IStreamable
    {
        public string Stream(string preferredContent)
        {
            return "Streaming live stream - " + preferredContent;
        }
    }
}