using System;

namespace LampPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            LampStates lamps = 0;
            int lamps_num = Enum.GetNames(typeof(LampStates)).Length;
            int buttons_num = lamps_num;
            int presses_left = 6;

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

                bool invalid_input = true;
                int selection = 0;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out int input) &
                    (0 < input) & (input <= buttons_num))
                    {
                        invalid_input = false;
                        selection = input-1;
                    }
                    else
                        Console.WriteLine("Invalid input");

                } while (invalid_input);


                lamps = ButtonPress(selection, lamps);



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
                    Console.WriteLine($"Lamps {button} and {button + 1}"+
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
