using System;
using System.Linq;
using System.Collections.Generic;

namespace StreamletExperience
{


    class Program
    {
        static void Main(string[] args)
        {
            int userPreference = 0;
            string stream="";
            Console.WriteLine("Web series, upcoming web series or currently live content?[W/U/L]?");
            string response = Console.ReadLine();
            switch (response.ToUpper())
            {
                case "W":
                    ContentLibrary library = new ContentLibrary();
                    Dictionary<int, string> webSeriesContent = library.GetLatestStaticContentList();
                    userPreference = askUserPreference(webSeriesContent);
                    string chosenStaticContent = library.GetStaticContentById(userPreference).Value;

                    IStreamable staticContentStreamer = new StaticContentStreamer();
                    stream = staticContentStreamer.Stream(chosenStaticContent);
                    Console.WriteLine(stream);
                    break;
                case "U":
                    ContentLibrary upCominglibrary = new ContentLibrary();
                    Dictionary<int, string> upcomingWebSeriesContent = upCominglibrary.GetUpcomingStaticContentList();
                    userPreference = askUserPreference(upcomingWebSeriesContent);
                    string chosenUpcomingStaticContent = upCominglibrary.GetUpcomingStaticContentById(userPreference).Value;

                    ITrailerStreamable trailerStreamer = new StaticContentStreamer();
                    stream = trailerStreamer.StreamTrailer(chosenUpcomingStaticContent);
                    Console.WriteLine(stream);
                    break;
                case "L":
                    ContentLibrary liveStreamContentlibrary = new ContentLibrary();
                    Dictionary<int, string> liveStreamContent = liveStreamContentlibrary.GetCurrentlyLiveStreamList();
                    userPreference = askUserPreference(liveStreamContent);
                    string chosenLiveStreamContent = liveStreamContentlibrary.GetLiveStreamContentById(userPreference).Value;

                    IStreamable liveStreamer = new LiveStreamContentStreamer();
                    stream = liveStreamer.Stream(chosenLiveStreamContent);
                    Console.WriteLine(stream);
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
