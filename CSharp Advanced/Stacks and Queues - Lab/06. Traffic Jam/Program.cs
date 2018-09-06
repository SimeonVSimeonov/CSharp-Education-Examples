using System;
using System.Collections.Generic;

namespace _06._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsCanPass = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int counter = 0;

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    int carsCount = queue.Count;

                    for (int i = 0; i < Math.Min(carsCount, carsCanPass); i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
