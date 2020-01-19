using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Slot_Machine
{
    class Program
    {
        static String diffStr = "";
        static bool isHard = false;
        static String[] letters = { "A", "B", "C" };
        static String[] ranLetters = { "", "", "" };
        static string helloMes =
                                @"  ___ ______________.____    .____    ________    ___________________       _____ _____.___.   ________    _____      _____  ___________
                                   /   |   \_ _____/|    |   |    |   \_____  \   \__ ___/\_____  \     /     \\__  |   |  /  _____/   /  _  \    /     \ \_ _____/
                                  /    ~    \    __)_ |    |   |    |    /   |   \    |    |    /   |   \   /  \ /  \/   |   | /   \  ___  /  /_\  \  /  \ /  \ |    __)_ 
                                  \    Y    /        \|    |___|    |___/    |    \   |    |   /    |    \ /    Y    \____   | \    \_\  \/    |    \/    Y    \|        \
                                   \___|_  /_______  /|_______ \_______ \_______  /   |____|   \_______  / \____|__  / ______|  \______  /\____|__  /\____|__  /_______  /
                                         \/        \/         \/       \/       \/                     \/          \/\/                \/         \/         \/        \/ ";

        static string diffMes =
@"_________   ___ ___ ________   ________    ____________________ ______________ ______________ ________  .______________.____________  ____ ___.____    .___________________.___.
\_   ___ \ /   |   \\_____  \  \_____  \  /   _____/\_   _____/ \__    ___/   |   \_   _____/ \______ \ |   \_   _____/|   \_   ___ \|    |   \    |   |   \__    ___/\__  |   |
/    \  \//    ~    \/   |   \  /   |   \ \_____  \  |    __)_    |    | /    ~    \    __)_   |    |  \|   ||    __)  |   /    \  \/|    |   /    |   |   | |    |    /   |   |
\     \___\    Y    /    |    \/    |    \/        \ |        \   |    | \    Y    /        \  |    `   \   ||     \   |   \     \___|    |  /|    |___|   | |    |    \____   |
 \______  /\___|_  /\_______  /\_______  /_______  //_______  /   |____|  \___|_  /_______  / /_______  /___|\___  /   |___|\______  /______/ |_______ \___| |____|    / ______|
        \/       \/         \/         \/        \/         \/                  \/        \/          \/         \/                \/                 \/               \/       ";

        static string diffChoiceMes = @"
\_   _____/ _____/  |_  ___________  /_   | _/ ____\___________                                             
 |    __)_ /    \   __\/ __ \_  __ \  |   | \   __\/  _ \_  __ \                                            
 |        \   |  \  | \  ___/|  | \/  |   |  |  | (  <_> )  | \/                                            
/_______  /___|  /__|  \___  >__|     |___|  |__|  \____/|__|                                               
        \/     \/          \/                                                                               
  ___ ___                  .___                _______      _____                                           
 /   |   \_____ _______  __| _/   ___________  \   _  \   _/ ____\___________    ____ _____    _________.__.
/    ~    \__  \\_  __ \/ __ |   /  _ \_  __ \ /  /_\  \  \   __\/  _ \_  __ \ _/ __ \\__  \  /  ___<   |  |
\    Y    // __ \|  | \/ /_/ |  (  <_> )  | \/ \  \_/   \  |  | (  <_> )  | \/ \  ___/ / __ \_\___ \ \___  |
 \___|_  /(____  /__|  \____ |   \____/|__|     \_____  /  |__|  \____/|__|     \___  >____  /____  >/ ____|
       \/      \/           \/                        \/                            \/     \/     \/ \/     ";

        static string wonMes = @"_____.___.________   ____ ___   __      __________    _______    ._. ._. ._.
                                  \__  |   |\_____  \ |    |   \ /  \    /  \_____  \   \      \   | | | | | |
                                    /   |   | /   |   \|    |   / \   \/\/   //   |   \  /   |   \  | | | | | |
                                    \____   |/    |    \    |  /   \        //    |    \/    |    \  \|  \|  \|
                                    / ______|\_______  /______/     \__/\  / \_______  /\____|__  /  __  __  __
                                    \/               \/                  \/          \/         \/   \/  \/  \/";

        static string loseMes = @"_____.___.________   ____ ___  .____    ________    ___________________   ___ ___    _____    ___ ___    _____    ___ ___    _____    ___ ___    _____    ___ ___    _____    .____    ________    ____________________________  ._._._.
                                  \__  |   |\_____  \ |    |   \ |    |   \_____  \  /   _____|__    ___/  /   |   \  /  _  \  /   |   \  /  _  \  /   |   \  /  _  \  /   |   \  /  _  \  /   |   \  /  _  \   |    |   \_____  \  /   _____|_   _____|______   \ | | | |
                                    /   |   | /   |   \|    |   / |    |    /   |   \ \_____  \  |    |    /    ~    \/  /_\  \/    ~    \/  /_\  \/    ~    \/  /_\  \/    ~    \/  /_\  \/    ~    \/  /_\  \  |    |    /   |   \ \_____  \ |    __)_ |       _/ | | | |
                                    \____   |/    |    \    |  /  |    |___/    |    \/        \ |    |    \    Y    /    |    \    Y    /    |    \    Y    /    |    \    Y    /    |    \    Y    /    |    \ |    |___/    |    \/        \|        \|    |   \  \|\|\|
                                    / ______|\_______  /______/   |_______ \_______  /_______  / |____| /\  \___|_  /\____|__  /\___|_  /\____|__  /\___|_  /\____|__  /\___|_  /\____|__  /\___|_  /\____|__  / |_______ \_______  /_______  /_______  /|____|_  /  ______
                                    \/               \/                   \/       \/        \/         )/        \/         \/       \/         \/       \/         \/       \/         \/       \/         \/          \/       \/        \/        \/        \/   \/\/\/";

        static string aChar = @"_____   
  /  _  \  
 /  /_\  \ 
/    |    \
\____|__  /
        \/ ";
        static string bChar = @"__________ 
\______   \.;
 |    |  _/
 |    |   \
 |______  /
        \/ ";
        static string cChar = @"_________  
\_   ___ \ 
/    \  \/ 
\     \____
 \______  /
        \/ ";

        static string spaceChar = @"             






                                                ";




        static System.Threading.Timer spinTimer; // TIMER FOR SPINNING 
        static double speedOfSpin = 50;                                       // SPEED OF SPINNING BEFORE IT STOPS COMPLETELY 
        static int spinCounter = 0;


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                                  " + helloMes);
            Console.WriteLine("" + diffMes);
            GetMode();
            Console.WriteLine("\n Press \'q\' to quit the game. \n \n");
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            spinTimer = new System.Threading.Timer(RunEvent, 10, 1, 100);

            while (Console.Read() != 'q');
        }

        static public void RunEvent(object args)
        {
            ++spinCounter;
            PrintLetters();

            if (spinCounter == 10)
            {
                if (IsWin)
                {
                    Console.WriteLine("                                  " + wonMes);
                }
                else
                {
                    Console.WriteLine("                                  " + loseMes);
                }
                spinTimer.Dispose();
            }
        }

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            speedOfSpin = speedOfSpin * 1.40;
            Console.Out.WriteLine("Hello To the Game!!! \n");
            Console.Out.WriteLine("Choose dificulty");
            GetMode();
            PrintLetters();
        }

        static void PrintLetters()
        {
                Thread.Sleep((int)speedOfSpin);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                GetRandomLetters();
                String letLine = "  |  " + ranLetters[0] + "  |  " + ranLetters[1] + "  |  " + ranLetters[2] + "  |  ";
                Console.Out.WriteLine(letLine);
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void GetRandomLetters()
        {
            // Create a Random object  
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(letters.Length);
            ranLetters[0] = letters[index];
            index = rand.Next(letters.Length);
            ranLetters[1] = letters[index];
            index = rand.Next(letters.Length);
            ranLetters[2] = letters[index];
        }

        static void GetMode()
        {
            Console.Out.WriteLine("" + diffChoiceMes);
            diffStr = Console.ReadLine();
            if (diffStr == "0")
            {
                isHard = false;
            }
            else if (diffStr == "1")
            {
                isHard = true;
            }
            else
            {
                GetMode();
            }
        }

        static private bool IsWin
        {
            get
            {
                if (ranLetters[0] == ranLetters[1] && ranLetters[1] == ranLetters[2])
                {
                    return true;
                }
                return false;
            }
        }
    }
}
