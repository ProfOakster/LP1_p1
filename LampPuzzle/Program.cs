using System;

namespace LampPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            LampStates[] lamps = InitArray();
            
            Console.WriteLine("");
        }


        static LampStates[] InitArray()
        {
            int lampAmount = Enum.GetNames(typeof(LampStates)).Length;
            
            LampStates[] lamps = new LampStates[lampAmount];
            return lamps;
        }


        static LampStates[] ButtonPress(int button, LampStates[] lamps)
        {

            if (button == 0)
            {
                lamps[0] ^= LampStates.lamp1;
                Console.WriteLine("The first lamp turned on!");
            }

            else
            {
                if ((lamps[button-1] & LampStates.lamp1)
                    != (lamps[button] & LampStates.lamp1))
                {
                    lamps[button-1] ^= LampStates.lamp1;
                    lamps[button] ^= LampStates.lamp2;
                    Console.WriteLine("Lamps "+ button +" and "+ (button+1) +
                                      " switched states!");
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
