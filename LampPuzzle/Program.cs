﻿using System;

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

            while (presses_left > 0)
            {

                Console.WriteLine($"You have {presses_left} turns left");
                Console.WriteLine("");






                presses_left -= 1;
            }


        }
    }
}
