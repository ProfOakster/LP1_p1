using System;
using System.Text;
namespace LampPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            LampStates lamps = 0;
            int lamps_num = Enum.GetNames(typeof(LampStates)).Length;
            int buttons_num = lamps_num;
            int presses_left = 6;

            Console.WriteLine("");
            Console.WriteLine("LAMP PUZZLE");
            Console.WriteLine("First button toggles first lamp");
            Console.WriteLine("others swap state of its lamp and its previous one");

            Console.WriteLine($"Light all lamps in {presses_left} moves!");
            DisplayLamps(lamps, lamps_num);

            while (presses_left > 0)
            {

                Console.WriteLine($"You have {presses_left} turns left");




                bool invalid_input = true;
                int selection = 0;
                do
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int int_input) &&
                    (0 < int_input) && (int_input <= buttons_num))
                    {
                        invalid_input = false;
                        selection = int_input - 1;
                    }
                    else if (input == "q")
                    {
                        selection = -1;
                        break;
                    }
                    else
                        Console.WriteLine("Invalid input!");

                } while (invalid_input);

                if (selection == -1)
                {
                    Console.WriteLine("You give up.");
                    break;
                }

                lamps = ButtonPress(selection, lamps);

                DisplayLamps(lamps, lamps_num);

                presses_left -= 1;

                if (CheckWin(lamps))
                    break;

            }

            if (CheckWin(lamps))
            {
                Console.WriteLine($"You won with {presses_left} turns left!");
            }
            else
            {
                Console.WriteLine("No turns left");
                Console.WriteLine("GAME OVER");
            }


        }
        static LampStates ButtonPress(int button, LampStates lamps)
        {

            if (button == 0)
            {
                lamps ^= LampStates.lamp1;
                Console.WriteLine("The first lamp toggled!");
            }

            else
            {
                if ((lamps & (LampStates)(1 << (button - 1)))
                    != (lamps & (LampStates)(1 << button)))
                {
                    lamps ^= (LampStates)(1 << (button - 1));
                    lamps ^= (LampStates)(1 << button);
                    Console.WriteLine("Lamps " + button + " and " + (button + 1) +
                                      " switched states!");
                }

                else
                {
                    Console.WriteLine("Nothing happened!");
                }
            }
            return lamps;
        }

        static bool CheckWin(LampStates lamps)
        {
            bool win = true;

            for (int i = 0; i < Enum.GetNames(typeof(LampStates)).Length; i++)
            {
                LampStates lampCheck = lamps & (LampStates)(1 << i);

                if (lampCheck != (LampStates)(1 << i))
                {
                    win = false;
                }
            }

            return win;
        }

        static void DisplayLamps(LampStates lamps, int lamps_num)
        {
            ConsoleColor reset = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 1; i <= lamps_num; i++)
            {
                char lamp;
                if ((lamps & (LampStates)(1 << i - 1)) == (LampStates)(1 << i - 1))
                    lamp = '\u25CF';
                else
                    lamp = '\u25CB';
                Console.WriteLine("Lamp{0,1} {1,-3}{2}", i, "-", lamp);
            }
            Console.ForegroundColor = reset;

        }



    }
}
