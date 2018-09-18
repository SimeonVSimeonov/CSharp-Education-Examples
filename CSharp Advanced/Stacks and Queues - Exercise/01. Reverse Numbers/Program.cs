using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var stack = new Stack<int>();

            foreach (var item in input)
            {
                stack.Push(item);
            }
            foreach (var item in stack)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
