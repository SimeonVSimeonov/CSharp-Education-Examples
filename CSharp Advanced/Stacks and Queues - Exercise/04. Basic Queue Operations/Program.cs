using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var enqCommand = inputCommand[0];
            var deqCommand = inputCommand[1];
            var checkCommand = inputCommand[2];
            var elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < enqCommand; i++)
            {
                queue.Enqueue(elements[i]);
            }
            for (int i = 0; i < deqCommand; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(checkCommand))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }

        }
    }
}
