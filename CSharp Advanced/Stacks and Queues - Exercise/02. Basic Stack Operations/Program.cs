using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var pushCommand = int.Parse(inputCommand[0]);
            var popCommand = int.Parse(inputCommand[1]);
            var checkCommand = int.Parse(inputCommand[2]);

            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < pushCommand; i++)
            {
                stack.Push(inputNumbers[i]);
            }

            for (int i = 0; i < popCommand; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(checkCommand))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }

            }
        }
    }
}
