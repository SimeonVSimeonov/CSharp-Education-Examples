﻿using System;

namespace _01._Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            switch (input)
            {
                case "Athlete":
                    Console.WriteLine("Water");
                    break;
                case "Businessman":
                    Console.WriteLine("Coffee");
                    break;
                case "Businesswoman":
                    Console.WriteLine("Coffee");
                    break;
                case "SoftUni Student":
                    Console.WriteLine("Beer");
                    break;
                default:
                    Console.WriteLine("Tea");
                    break;
            }
        }
    }
}
