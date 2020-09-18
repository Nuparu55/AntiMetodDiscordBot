using System;
using System.Collections.Generic;
using System.Text;

namespace AntiMetodDiscordBot.XSD
{
    public class Affixes
    {
        public string region;
        public string title;
        public string leaderboard_url;
        public List<Details> affix_details;
    }

    public class Details
    {
        public int id;
        public string name;
        public string description;
        public string wowhead_url;
    }
}
