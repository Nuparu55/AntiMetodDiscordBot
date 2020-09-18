using System;

namespace AntiMetodDiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.MainTask(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
