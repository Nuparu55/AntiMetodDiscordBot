using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntiMetodDiscordBot.XSD
{
    public class Character
    {
        public string name;
        [JsonProperty("class")]
        public string playedClass;
        public string profile_url;
        public MythicPlusRankings mythic_plus_ranks;
        public MythicPlusScores mythic_plus_scores;
        public RaidProgression raid_progression;
        public Gear gear;
    }

    public class Gear
    {
        public double item_level_equipped;
    }
}
