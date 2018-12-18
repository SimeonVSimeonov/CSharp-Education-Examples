using System;
using System.Collections.Generic;
using System.Linq;

namespace P01ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();

            Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList()
                .ForEach(n => nums.Push(n));

            Console.WriteLine(string.Join(" ",nums.ToArray()));
        }
    }
}
