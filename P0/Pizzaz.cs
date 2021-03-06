using System;
using static System.Console;

namespace P0
{
    class Pizzaz
    {
        public static void Blink(string text, int blinkCount = 5, int onTime = 500, int offTime = 200)
        {
            CursorVisible = false;
            for (int i = 0; i < blinkCount; i++)
            {
                WriteLine(text);
                Thread.Sleep(onTime);
                Clear();
                Thread.Sleep(offTime);
            }
            CursorVisible = true;
        }

        public static void Typing(string text, int delay = 25)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Write(text[i]);
                Thread.Sleep(delay);
                if (KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Write(text.Substring(i + 1));
                        break;
                    }
                }
            }
            WriteLine();
        }

        public static void Titlecard()
        {
            string name = @"
     ██╗ █████╗ ██╗  ██╗███████╗    ███╗   ██╗ ██████╗ ██╗   ██╗██╗   ██╗███████╗███╗   ██╗
     ██║██╔══██╗██║ ██╔╝██╔════╝    ████╗  ██║██╔════╝ ██║   ██║╚██╗ ██╔╝██╔════╝████╗  ██║
     ██║███████║█████╔╝ █████╗      ██╔██╗ ██║██║  ███╗██║   ██║ ╚████╔╝ █████╗  ██╔██╗ ██║
██   ██║██╔══██║██╔═██╗ ██╔══╝      ██║╚██╗██║██║   ██║██║   ██║  ╚██╔╝  ██╔══╝  ██║╚██╗██║
╚█████╔╝██║  ██║██║  ██╗███████╗    ██║ ╚████║╚██████╔╝╚██████╔╝   ██║   ███████╗██║ ╚████║
 ╚════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═══╝ ╚═════╝  ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═══╝";
            string title = @"
   ▄████████    ▄█    █▄     ▄██████▄   ▄██████▄      ███      ▄██████▄  ███    █▄      ███     
  ███    ███   ███    ███   ███    ███ ███    ███ ▀█████████▄ ███    ███ ███    ███ ▀█████████▄ 
  ███    █▀    ███    ███   ███    ███ ███    ███    ▀███▀▀██ ███    ███ ███    ███    ▀███▀▀██ 
  ███         ▄███▄▄▄▄███▄▄ ███    ███ ███    ███     ███   ▀ ███    ███ ███    ███     ███   ▀ 
▀███████████ ▀▀███▀▀▀▀███▀  ███    ███ ███    ███     ███     ███    ███ ███    ███     ███     
         ███   ███    ███   ███    ███ ███    ███     ███     ███    ███ ███    ███     ███     
   ▄█    ███   ███    ███   ███    ███ ███    ███     ███     ███    ███ ███    ███     ███     
 ▄████████▀    ███    █▀     ▀██████▀   ▀██████▀     ▄████▀    ▀██████▀  ████████▀     ▄████▀";
            Typing(name, 1);
            Typing("\npresents...", 200);
            ReadKey();
            Clear();
            Blink(title, 4, 800, 200);
            WriteLine(title);
            CursorVisible = false;
            ReadKey();
            CursorVisible = true;
        }

        public static void finalMessage(int message)
        {
            string win = @"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗ ██████╗ ███╗   ██╗██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██╔═══██╗████╗  ██║██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║   ██║██╔██╗ ██║██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║   ██║██║╚██╗██║╚═╝
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝╚██████╔╝██║ ╚████║██╗
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═══╝╚═╝";
            string lose = @"
▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄  ▐██▌ 
 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌ ▐██▌ 
  ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌ ▐██▌ 
  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌ ▓██▒ 
  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓  ▒▄▄  
   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒  ░▀▀▒ 
 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒  ░  ░ 
 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░     ░ 
 ░ ░         ░ ░     ░           ░     ░     ░  ░   ░     ░    
 ░ ░                           ░                  ░";
            string tied = "There are no victors... no survivors...";
            switch (message)
            {
                case 1:
                    WriteLine();
                    Typing(win, 1);
                    break;
                case 2:
                    WriteLine();
                    Typing(lose, 1);
                    break;
                case 3:
                    WriteLine();
                    Typing(tied);
                    Typing(lose, 1);
                    break;
            }
        }
    }
}