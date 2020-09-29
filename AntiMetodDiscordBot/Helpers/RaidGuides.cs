using System;
using System.Collections.Generic;
using System.Text;

namespace AntiMetodDiscordBot.Helpers
{
    public static class RaidGuides
    {
        public enum RaidDifficult
        {
            Normal,
            Heroic,
            Mythical
        }
        public static string GetBossGuide(RaidDifficult difficult, string bossName)
        {
            var bossGuideUrl = "Вот ссылка на интересующего тебя босса: ";

            if (difficult == RaidDifficult.Mythical)
                return "Погодь, в мою базу еще не вбили ссылки для мификов.";

            switch (bossName)
            {
                case "гневион":
                    bossGuideUrl += "https://www.youtube.com/watch?v=Jj3ds_MX4t8&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=1";
                    break;

                case "маут":
                    bossGuideUrl += "https://www.youtube.com/watch?v=TEoGUJozN_I&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=2";
                    break;

                case "пророк скитра":
                case "скитра":
                    bossGuideUrl += "https://www.youtube.com/watch?v=s7Hs6fwetDk&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=3";
                    break;

                case "темный инквизитор занеш":
                case "темный инквизитор":
                case "инквизитор":
                case "инквизитор занеш":
                case "занеш":
                    bossGuideUrl += "https://www.youtube.com/watch?v=6vhm5WvscTI&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=4";
                    break;

                case "коллективный разум":
                case "разум":
                    bossGuideUrl += "https://www.youtube.com/watch?v=OZThhJLDWds&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=5";
                    break;

                case "шад'хар ненасытный":
                case "шадхар ненасытный":
                case "шад'хар":
                case "шадхар":
                    bossGuideUrl += "https://www.youtube.com/watch?v=A1E6B6j-26U&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=6";
                    break;

                case "дест'агат":
                case "дестагат":
                    bossGuideUrl += "https://www.youtube.com/watch?v=W1zuTT1ua1A&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=7";
                    break;

                case "ил'гинот возрожденная порча":
                case "илгинот возрожденная порча":
                case "ил'гинот":
                case "илгинот":
                    bossGuideUrl += "https://www.youtube.com/watch?v=MM80XKMfsmY&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=8";
                    break;

                case "вексиона":
                case "векса":
                    bossGuideUrl += "https://www.youtube.com/watch?v=dezbYvQfuhA&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=9";
                        break;

                case "ра-ден отчаявшийся":
                case "раден отчаявшийся":
                case "ра-ден":
                case "раден":
                    bossGuideUrl += "https://www.youtube.com/watch?v=yc_IpVzWs_o&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=10";
                        break;

                case "панцирь н'зота":
                case "панцирь нзота":
                case "панцирь":
                    bossGuideUrl += "https://www.youtube.com/watch?v=0Gatp75y6HI&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=11";
                        break;

                case "н'зот заразитель":
                case "нзот заразитель":
                case "н'зот":
                case "нзот":
                    bossGuideUrl += "https://www.youtube.com/watch?v=AcrXx2U2wIc&list=PLJjqVD7EUL48AFlVNvcLInhX-o_B7x8Ug&index=12";
                        break;

                default:
                    bossGuideUrl = "Извини, я не нашел нужный тебе гайд. Наверное потому, что ты, обмудок, не можешь нормально написать его имя, долбоеб!";
                    break;
            }

            return bossGuideUrl;
        }
    }
}
