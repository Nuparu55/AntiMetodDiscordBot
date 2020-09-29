using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Net;
using DSharpPlus.Net.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AntiMetodDiscordBot;
using AntiMetodDiscordBot.API;
using AntiMetodDiscordBot.Helpers;
using static AntiMetodDiscordBot.Helpers.RaidGuides;

namespace AntiMetodDiscordBot
{
    public class Bot
    {
        public DiscordClient client { get; private set; }
        public string token;
        private Random _rnd;
        public Bot()
        {
            token = ConfigurationManager.AppSettings["token"];
            _rnd = new Random();
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
            client.Ready += async e =>
            {
                var game = new DiscordGame("твоем очке");
                game.Application = client.CurrentApplication;
                await client.UpdateStatusAsync(game);
            };

            client.MessageCreated += async e =>
            {
                if (e.Channel.Name.ToLower() == "анти-бот")
                {
                    string message = e.Message.Content;

                    if (message.ToLower().StartsWith("инфобот"))
                    {
                        var messageToSend =
                        $"Приветствую тебя, участник наипиздатейшей гильдии АнтиМетод (если ты не участник, то ливай и заодно обоссы себе ебальник, чорт, хули ты тут забыл).{Environment.NewLine}" +
                        $"Вот комманды, по которым я могу выдать тебе полезную информацию (или послать нахуй, тут по настроению):{Environment.NewLine}" +
                        $"Персонаж: *Сервер*, *Ник персонажа* - Выдам инфу по любому существующему персонажу.{Environment.NewLine}" +
                        $"Гильдия: *Сервер*, *Название гильдии* - Аналогично персонажу выдам полезную информацию по запрашиваемой гильдии.{Environment.NewLine}" +
                        $"Аффиксы - Аффиксы текущей недели и их подробное описание на EU регионе.{Environment.NewLine}" +
                        $"Гайд: *Сложность одной буквой (N - нормал, H - героик, M - мифик)* - Постараюсь найти для тебя видеогайд по прохождению интересующего тебя рейдового босса.";
                        await e.Message.RespondAsync(messageToSend);
                    }
                    else if (message.ToLower().StartsWith("персонаж:"))
                    {
                        try
                        {
                            await e.Message.RespondAsync(MessageBuilder.CharacterAnswer(message));
                        }
                        catch (WebException ex)
                        {
                            await e.Message.RespondAsync($"Произошла ошибка - (если тебе это что то даст, то {ex.Message}). {Environment.NewLine}Тут то ли ты вместо имени персонажа или сервера хуйню написал, то ли я дурак. {Environment.NewLine}Зовите Макса, пусть разбирается, хули.");
                        }
                    }
                    else if (message.ToLower().StartsWith("гильдия:"))
                    {
                        try
                        {
                            await e.Message.RespondAsync(MessageBuilder.GuildAnswer(message));
                        }
                        catch (WebException ex)
                        {
                            await e.Message.RespondAsync($"Произошла ошибка - (если тебе это что то даст, то {ex.Message}). {Environment.NewLine}Тут то ли ты вместо названия гильдии или сервера хуйню написал, то ли я дурак. {Environment.NewLine}Зовите Макса, пусть разбирается, хули.");
                        }
                    }
                    else if (message.ToLower() == "аффиксы")
                    {
                        try
                        {
                            await e.Message.RespondAsync(MessageBuilder.AffixAnswer());
                        }
                        catch (WebException ex)
                        {
                            await e.Message.RespondAsync($"Произошла ошибка - (если тебе это что то даст, то {ex.Message}). {Environment.NewLine}Зовите Макса, пусть разбирается, хули.");
                        }
                    }
                    else if (message.ToLower().StartsWith("гайд:"))
                    {
                        var parsedMessage = message.Replace("гайд:", "").Replace("Гайд:", "").Split(',');
                        if (parsedMessage.Length != 2)
                            await e.Message.RespondAsync("Нормально напиши, блять, сложность и имя босса через запятую, полудурок");

                        var dif = parsedMessage[0].ToLower().Trim();
                        var bossName = parsedMessage[1].ToLower().Trim();

                        switch (dif)
                        {
                            case "n":
                                await e.Message.RespondAsync(RaidGuides.GetBossGuide(RaidDifficult.Normal, bossName));
                                break;
                            case "h":
                                await e.Message.RespondAsync(RaidGuides.GetBossGuide(RaidDifficult.Heroic, bossName));
                                break;
                            case "m":
                                await e.Message.RespondAsync(RaidGuides.GetBossGuide(RaidDifficult.Mythical, bossName));
                                break;
                            default:
                                await e.Message.RespondAsync("Ты че, блять, сложность указать не можешь, дефеченто? Если не знаешь, как писать запросы, напиши \"Инфобот\", уебан, и узнай, как сука сложность указывать.");
                                break;
                        }
                    }
                    else if (message.ToLower() == "рандомная тян")
                    {
                        string[] tyans = { 
                            "http://img1.joyreactor.cc/pics/post/full/Anime-Nora-cat-nora-cat-channel-sunsuke-4291251.png",
                            "https://i.pinimg.com/736x/1b/33/07/1b330700beab0801c6aa8a4392fd9461.jpg",
                            "https://trikky.ru/wp-content/blogs.dir/1/files/2019/11/15/0674654f7d9b9ed91a3a6f92e08823bf.jpg" };

                        var tyan = tyans[_rnd.Next(3)];

                        var builder = new DiscordEmbedBuilder();
                        builder.ImageUrl = tyan;
                        await e.Message.RespondAsync(null, false, builder.Build());
                    }
                    else if (message.ToLower() == "вилкой чисти")
                    {
                        var last = e.Channel.LastMessageId;
                        var messages = e.Channel.GetMessagesAsync(100, last).Result;
                        while (messages.Any())
                        {
                            e.Channel.DeleteMessagesAsync(messages).Wait();
                            last = e.Channel.LastMessageId;
                            messages = e.Channel.GetMessagesAsync(100, last).Result;
                        }
                    }
                }
            };

            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
