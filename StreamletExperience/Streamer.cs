using System;
using System.Collections.Generic;

namespace StreamletExperience
{
    public interface IStreamable
    {
        string Stream(string preferredContent);
    }

    public interface ITrailerStreamable
    {
        string StreamTrailer(string preferredContent);
    }
    public class StaticContentStreamer : IStreamable,ITrailerStreamable
    {

        public string Stream(string preferredContent)
        {
            return "Streaming web series - " + preferredContent;
        }

        public string StreamTrailer(string preferredContent)
        {
            return "Streaming web series trailer- " + preferredContent;
        }
    }

    public class LiveStreamContentStreamer : IStreamable,ITrailerStreamable
    {
        public string Stream(string preferredContent)
        {
            return "Streaming live stream - " + preferredContent;
        }

        public string StreamTrailer(string preferredContent)
        {
            return "Streaming live stream trailer- " + preferredContent;
        }
    }
    public class UpcomingStaticContentStreamer : ITrailerStreamable
    {
        public string StreamTrailer(string preferredContent)
        {
            return "Streaming upcoming web series trailer- " + preferredContent;
        }
    }
}