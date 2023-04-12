using System;

namespace LampPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }

        static LampStates ButtonPress(int button)
        {
            LampStates lamps = 0;

            if (button == 1)
            {
                lamps ^= LampStates.lamp1;
                Console.WriteLine("The first lamp turned on!");
            }

            else if (button == 2)
            {
                if ((lamps & LampStates.lamp1) != (lamps & LampStates.lamp1))
                {
                    lamps ^= LampStates.lamp1;
                    lamps ^= LampStates.lamp2;
                    Console.WriteLine("Lamps 1 and 2 switched states!");
                }

                else
                {
                    Console.WriteLine("Nothing happened!");
                }
            }
            
            else if (button == 3)
            {
                if ((lamps & LampStates.lamp1) != (lamps & LampStates.lamp1))
                {
                    lamps ^= LampStates.lamp2;
                    lamps ^= LampStates.lamp3;
                    Console.WriteLine("Lamps 2 and 3 switched states!");
                }

                else
                {
                    Console.WriteLine("Nothing happened!");
                }
            }

            return lamps;
        }
    }
}
