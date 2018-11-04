using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Square_Numbers_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> square = new List<int>();

            foreach (var item in input)
            {
                if (Math.Sqrt(item)==Math.Floor(Math.Sqrt(item)))
                {
                    square.Add(item);
                }
            }
            square.Sort();
            square.Reverse();
            Console.WriteLine(string.Join(" ",square));
        }
    }
}
