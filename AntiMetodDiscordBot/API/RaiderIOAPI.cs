using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using AntiMetodDiscordBot.XSD;
using Newtonsoft.Json;

namespace AntiMetodDiscordBot.API
{
    public static class RaiderIOAPI
    {
        public static Character SendRequestForCharacter(string region, string realm, string name)
        {
            Uri uri = new Uri($"https://raider.io/api/v1/characters/profile?region={region}&realm={realm}&name={name}&fields=mythic_plus_scores,raid_progression,gear");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = sr.ReadToEnd();
                var json = JsonConvert.DeserializeObject<Character>(response);
                return json;
            }
        }

        public static Guild SendRequestForGuild(string region, string realm, string name)
        {
            Uri uri = new Uri($"https://raider.io/api/v1/guilds/profile?region={region}&realm={realm}&name={name}&fields=raid_progression");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = sr.ReadToEnd();
                var json = JsonConvert.DeserializeObject<Guild>(response);
                return json;
            }
        }
    }
}
