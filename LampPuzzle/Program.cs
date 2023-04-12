using System;

namespace LampPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            LampStates lamps = 0;
            
            Console.WriteLine("");
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
                if ((lamps & (LampStates) (1 << (button-1)))
                    != (lamps & (LampStates) (1 << button)))
                {
                    lamps ^= (LampStates) (1 << (button-1));
                    lamps ^= (LampStates) (1 << button);
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

        static bool CheckWin(LampStates lamps)
        {
            bool win = true;

            for (int i = 0; i < Enum.GetNames(typeof(LampStates)).Length; i++)
            {
                LampStates lampCheck = lamps & (LampStates)(1 << i);

                if (lampCheck != (LampStates) (1 << i))
                {
                    win = false;
                }
            }

            return win;
        }
    }
}
