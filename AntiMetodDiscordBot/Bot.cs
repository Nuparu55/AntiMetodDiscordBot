using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AntiMetodDiscordBot;
using AntiMetodDiscordBot.API;

namespace AntiMetodDiscordBot
{
    public class Bot
    {
        public DiscordClient client { get; private set; }
        public string token;
        public Bot()
        {
            token = ConfigurationManager.AppSettings["token"];
        }
        public async Task MainTask(string[] args)
        {
            var config = new DiscordConfiguration()
            {
                Token = token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            };

            client = new DiscordClient(config);

            client.MessageCreated += async e =>
            {
                string message = e.Message.Content;
                if (message.StartsWith("Персонаж:"))
                {
                    var messageToSend = message.Replace(" ", "").Replace("Персонаж:", "").Split(',');
                    try
                    {
                        var character = RaiderIOAPI.SendRequestForCharacter("eu", messageToSend[0], messageToSend[1]);

                        if (character.gear.item_level_equipped < 430)
                            await e.Message.RespondAsync("Фу бля, ты даже не 430 илвл, ты ебанулся мне запросы отправлять???");
                        else if (character.mythic_plus_scores.all < 100)
                            await e.Message.RespondAsync("Пизда, нету даже сотки RIO, твое место у параши.");
                        else
                        {
                            await e.Message.RespondAsync(
                                $"Имя: {character.name}{Environment.NewLine}" +
                                $"Класс: {character.playedClass}{Environment.NewLine}" +
                                $"Илвл: {character.gear.item_level_equipped}{Environment.NewLine}" +
                                $"Raider.IO: {character.mythic_plus_scores.all}{Environment.NewLine}" +
                                $"Прогресс Ниалоты: {character.raid_progression.nyalotha.summary}{Environment.NewLine}" +
                                $"Ссылка на Raider.IO: {character.profile_url}"
                                );
                        }
                    }
                    catch (WebException ex)
                    {
                        await e.Message.RespondAsync($"Произошла ошибка - {ex.Message}");
                    }
                }
                else if (message.StartsWith("Гильдия:"))
                {
                    var messageToSend = message.Replace(" ", "").Replace("Гильдия:", "").Split(',');
                    try
                    {
                        var guild = RaiderIOAPI.SendRequestForGuild("eu", messageToSend[0], messageToSend[1]);
                        await e.Message.RespondAsync(
                            $"Гильдия: {guild.name}{Environment.NewLine}" +
                            $"Прогресс Ниалоты: {guild.raid_progression.nyalotha.summary}{Environment.NewLine}" +
                            $"Ссылка на Raider.IO: {guild.profile_url}");
                    }
                    catch (WebException ex)
                    {
                        await e.Message.RespondAsync($"Произошла ошибка - {ex.Message}");
                    }
                }
            };

            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
