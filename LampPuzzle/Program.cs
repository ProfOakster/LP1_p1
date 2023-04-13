using System;

namespace LampPuzzle
{
    /// <summary>
    /// Contains the Main code, along with ButtonPress and CheckWin methods.
    /// </summary>
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
        /// <summary>
        /// Recieves the number of the button pressed and the variable 
        /// containing the lamp states, executing the button's action and
        /// updating the variable.
        /// </summary>
        /// <param name="button">Number of the button pressed
        /// ( The first button is '0' )</param>
        /// <param name="lamps">The variable containing the lamp states</param>
        /// <returns>An updated LampStates variable after the button's
        /// effect on it. </returns>
        static LampStates ButtonPress(int button, LampStates lamps)
        {

            /// Checks if the first button was pressed
            if (button == 0)
            {
                ///Toggles the state of the first lamp, and prints feedback.
                lamps ^= LampStates.lamp1;
                Console.WriteLine("The first lamp toggled!");
            }

            /// For every button other than the first:
            else
            {
                /// Checks if the lamp next to the button and the one before it
                /// have different states (if one is off and the other is on)
                if ((lamps & (LampStates)(1 << (button - 1)))
                    != (lamps & (LampStates)(1 << button)))
                {
                    ///Toggles both lamps and prints feedback to the console.
                    lamps ^= (LampStates)(1 << (button - 1));
                    lamps ^= (LampStates)(1 << button);
                    Console.WriteLine($"Lamps {button} and {button + 1}"+
                                      " switched states!");
                }

                /// If the two lamps have the same state, nothing changes and
                /// feedback is printed to the console.
                else
                {
                    Console.WriteLine("Nothing happened!");
                }
            }
            /// Returns an updated LampState variable.
            return lamps;
        }

        /// <summary>
        /// Recieves the variable containing the lamp states and checks if
        /// any of them is turned off.
        /// </summary>
        /// <param name="lamps"></param>
        /// <returns>True if all lamps are on;
        /// False if at least one lamp is off.</returns>
        static bool CheckWin(LampStates lamps)
        {
            /// Initializes a bool set to True, to be returned.
            bool win = true;

            /// Checks every individual lamp on the variable given.
            for (int i = 0; i < Enum.GetNames(typeof(LampStates)).Length; i++)
            {
                /// Initializes a second LampStates variable that checks if the
                /// given variable has the lamp turned on.
                LampStates lampCheck = lamps & (LampStates)(1 << i);

                // If any lamp isn't on, changes the bool to False.
                if (lampCheck != (LampStates)(1 << i))
                {
                    win = false;
                }
            }

            /// Returns the bool. If all lamps are on, returns true. Else,
            /// if at least one lamp is off, returns false.
            return win;
        }
    }
}
