using System;
using System.Linq;
using System.Collections.Generic;

namespace StreamletExperience
{
    public class ContentLibrary
    {
        public Dictionary<int, string> GetLatestStaticContentList()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "Hawkeye");
            list.Add(2, "The Wheel of Time");
            list.Add(3, "Special Ops 1.5");
            list.Add(4, "Red Notice");
            list.Add(5, "Break Point");
            return list;
        }

        public KeyValuePair<int,string> GetStaticContentById(int id)
        {
            return GetLatestStaticContentList().FirstOrDefault(x=>x.Key==id);
        }

         public Dictionary<int, string> GetUpcomingLiveStreamList()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "Ghanti Bajao LIVE with Akhilesh Anand");
            list.Add(2, "Free Fire Asia Championship[Hindi]");
            list.Add(3, "Free Fire Asia Championship[English]");
            list.Add(4, "Ind/NZ 1st test match Day 3");
            list.Add(5, "Mann ki baat - Narendra Modi");
            return list;
        }
        public KeyValuePair<int,string> GetLiveStreamContentById(int id)
        {
            return GetUpcomingLiveStreamList().FirstOrDefault(x=>x.Key==id);
        }
    }
}