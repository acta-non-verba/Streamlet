using System;
using System.Linq;
using System.Collections.Generic;

namespace StreamletExperience
{


    class Program
    {
        static void Main(string[] args)
        {
            int userPreference=0;
            Console.WriteLine("Web series or Livestream content?[W/L]?");
            string response = Console.ReadLine();
            switch (response.ToUpper())
            {
                case "W":
                    ContentLibrary library = new ContentLibrary();
                    Dictionary<int, string> webSeriesContent = library.GetLatestStaticContentList();
                    userPreference =askUserPreference(webSeriesContent);
                    string chosenStaticContent = library.GetStaticContentById(userPreference).Value;

                    IStreamable staticContentStreamer = new StaticContentStreamer();
                    string staticContentStream = staticContentStreamer.Stream(chosenStaticContent);
                    Console.WriteLine(staticContentStream);
                    break;
                case "L":
                    ContentLibrary liveStreamContentlibrary = new ContentLibrary();
                    Dictionary<int, string> liveStreamContent = liveStreamContentlibrary.GetUpcomingLiveStreamList();
                    userPreference = askUserPreference(liveStreamContent);
                    string chosenLiveStreamContent = liveStreamContentlibrary.GetLiveStreamContentById(userPreference).Value;

                    IStreamable liveStreamContentStreamer = new LiveStreamContentStreamer();
                    string liveStreamContentStream = liveStreamContentStreamer.Stream(chosenLiveStreamContent);
                    Console.WriteLine(liveStreamContentStream);
                    break;
                default:
                    break;
            }
        }

        private static int askUserPreference(Dictionary<int, string> content)
        {
            foreach (var item in content)
            {
                Console.WriteLine("Respond with {0} for {1}", item.Key, item.Value);
            }
            int userPreference = Convert.ToInt32(Console.ReadLine());
            return userPreference;
        }
    }
}
