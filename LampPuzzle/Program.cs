using System;

namespace LampPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {

            int presses_left = 6;
            LampStates lamps = 0;
            Console.WriteLine("");
            Console.WriteLine("LAMP PUZZLE");
            Console.WriteLine("First button toggles first lamp");
            Console.WriteLine("others swap state of its lamp and its previous one");

            Console.WriteLine($"Light all lamps in {presses_left} moves!");

            bool win = false;
            while (presses_left > 0)
            {

                Console.WriteLine($"You have {presses_left} turns left");
                Console.WriteLine(lamps);

                int input = int.Parse(Console.ReadLine()); //try adding tryparse

                lamps = ButtonPress(input - 1, lamps);



                presses_left -= 1;

                if (CheckWin(lamps))
                {
                    win = true;
                    break;
                }
            }

            if (win)
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
    }
}
