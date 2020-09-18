using System;
using AntiMetodDiscordBot.API;

namespace AntiMetodDiscordBot.Helpers
{
    public static class MessageBuilder
    {
        public static string CharacterAnswer(string message)
        {
            var messageToSend = message.Replace(" ", "").Replace("персонаж:", "").Replace("Персонаж:", "").Split(',');

            var character = RaiderIOAPI.SendRequestForCharacter("eu", messageToSend[0], messageToSend[1]);

            if (character.gear.item_level_equipped < 430)
                return "Фу бля, ты даже не 430 илвл, ты ебанулся мне запросы отправлять???";
            else if (character.mythic_plus_scores.all < 100)
                return "Пизда, нету даже сотки RIO, твое место у параши.";
            else
            {
                return
                    $"Имя: {character.name}{Environment.NewLine}" +
                    $"Класс: {character.playedClass}{Environment.NewLine}" +
                    $"Илвл: {character.gear.item_level_equipped}{Environment.NewLine}" +
                    $"Raider.IO: {character.mythic_plus_scores.all}{Environment.NewLine}" +
                    $"Прогресс Ниалоты: {character.raid_progression.nyalotha.summary}{Environment.NewLine}" +
                    $"Ссылка на Raider.IO: {character.profile_url}"
                    ;
            }
        }
        public static string GuildAnswer(string message)
        {
            var guildFromMessage = message.Split(',')[1].Trim().Replace(" ", "%20");
            var otherFromMessage = message.Split(',')[0].Replace(" ", "").Replace("гильдия:", "").Replace("Гильдия:", "");
            var guild = RaiderIOAPI.SendRequestForGuild("eu", otherFromMessage, guildFromMessage);
            return
                $"Гильдия: {guild.name}{Environment.NewLine}" +
                $"Прогресс Ниалоты: {guild.raid_progression.nyalotha.summary}{Environment.NewLine}" +
                $"Ссылка на Raider.IO: {guild.profile_url}";
        }

        public static string AffixAnswer()
        {
            var affixes = RaiderIOAPI.SendRequestForAffixes();

            var answer =
                $"Итак-с, текущие аффиксы на этой неделе:{Environment.NewLine}" +
                $"{affixes.title}{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"Разберем каждый из них:{Environment.NewLine}{Environment.NewLine}";

            var affixesString = String.Empty;

            foreach (var a in affixes.affix_details)
            {
                affixesString += $"{a.name}: {a.description}{Environment.NewLine}{Environment.NewLine}";
            }

            answer += affixesString;

            answer += $"{Environment.NewLine}Лидерборд тут: {affixes.leaderboard_url}";

            return answer;
        }
    }
}
