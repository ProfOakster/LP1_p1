using System;
using System.Text;
namespace LampPuzzle
{
    /// <summary>
    /// Contains the Main code, along with ButtonPress and CheckWin methods.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Implementation of the Lamp Puzzle with 3 lamps and 3 buttons
        /// </summary>
        /// <param name="args">Unused.</param>
        static void Main(string[] args)
        {
            //Enables writing unicode to command line
            Console.OutputEncoding = Encoding.UTF8;

            //Declaration of basic variables
            LampStates lamps = 0;
            int lamps_num = Enum.GetNames(typeof(LampStates)).Length;
            int buttons_num = lamps_num;
            int presses_left = 6;

            //Player instructions
            Console.WriteLine("--------------------------");
            Console.WriteLine("{0,18}", "LAMP PUZZLE");
            Console.WriteLine("--------------------------");

            Console.WriteLine("There are {0} lamps and {1} buttons;",
             lamps_num, buttons_num);
            Console.WriteLine("Pressing the first button toggles the first " +
            "lamp between on and off;");
            Console.WriteLine("The others swap the states between its " +
            "corresponding lamp and its previous one");
            Console.WriteLine("(Input a number to press that button)");
            Console.WriteLine(@"(Input 'q' to Quit)");
            Console.WriteLine($"Try to light all lamps in {presses_left} moves!");
            Console.WriteLine("--------------------------");

            //Game loop; Each cycle corresponds to 1 turn; Ends when out of turns
            while (presses_left > 0)
            {
                DisplayLamps(lamps, lamps_num);

                string message = presses_left switch
                {
                    1 => "You have 1 turn left.",
                    _ => String.Format($"You have {presses_left} turns left."),
                };
                Console.WriteLine(message);

                //User input cycle; Keeps asking until a valid input is received
                //Valid inputs are real numbers between 1 and the number of
                //buttons, or "q" to quit
                bool invalid_input = true;
                int selection = 0;
                do
                {
                    string input = Console.ReadLine();
                    //If input can be converted to an int between 1 and 
                    //buttons_num
                    if (int.TryParse(input, out int int_input) &&
                    (0 < int_input) && (int_input <= buttons_num))
                    {
                        invalid_input = false;
                        selection = int_input - 1;
                    }
                    else if (input == "q")
                    {
                        invalid_input = false;
                        selection = -1;
                        
                    }
                    else
                        Console.WriteLine("Invalid input!");

                } while (invalid_input);

                //When player wants to Quit
                //Skips straight to Game Over
                if (selection == -1)
                {
                    Console.WriteLine("You give up.");
                    break;
                }

                //Alters lamps according to button pressed
                lamps = ButtonPress(selection, lamps);


                Console.WriteLine("--------------------------");
                presses_left -= 1;

                //Checks if player won with moves to spare
                if (CheckWin(lamps))
                    break;

            }

            //Displays victory or loss message
            if (CheckWin(lamps))
            {
                string message = presses_left switch
                {
                    1 => "You won with 1 turn left!",
                    _ => String.Format($"You won with {presses_left} turns left!"),
                };
                Console.WriteLine(message);
            }
            else
            {
                if (presses_left == 0)
                    Console.WriteLine("No turns left");
                Console.WriteLine("GAME OVER");
            }


        }
        /// <summary>
        /// Receives the number of the button pressed and the variable 
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
                    Console.WriteLine($"Lamps {button} and {button + 1}" +
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
        /// <param name="lamps">The variable containing the lamp states</param>
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

        /// <summary>
        /// Displays the current state of all the lamps on the command line
        /// </summary>
        /// <param name="lamps">Variable containing the lamp states</param>
        /// <param name="lamps_num">Variable containing the number of lamps</param>
        static void DisplayLamps(LampStates lamps, int lamps_num)
        {
            //Stores the console foreground's current color 
            //and changes it to yellow
            ConsoleColor reset = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Displays the lamp number and a corresponding unicode character 
            //according to its state
            for (int i = 1; i <= lamps_num; i++)
            {
                char lamp;
                if ((lamps & (LampStates)(1 << i - 1)) == (LampStates)(1 << i - 1))
                    lamp = '\u25CF';
                else
                    lamp = '\u25CB';
                Console.WriteLine("Lamp{0,1} {1,-3}{2}", i, "-", lamp);
            }
            //Resets the console foreground's color
            Console.ForegroundColor = reset;
        }



    }
}
