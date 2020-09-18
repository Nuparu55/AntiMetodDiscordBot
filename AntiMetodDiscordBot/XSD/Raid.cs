using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntiMetodDiscordBot.XSD
{
    public class RaidProgression
    {
        [JsonProperty("nyalotha-the-waking-city")]
        public Nyalotha nyalotha;
    }
    public class Nyalotha
    {
        public string summary;
    }
}
