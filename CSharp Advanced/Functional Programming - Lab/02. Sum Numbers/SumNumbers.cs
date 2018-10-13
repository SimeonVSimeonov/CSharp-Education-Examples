using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(Parse)
                .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }

        public static Func<string, int> Parse = n => Int32.Parse(n);
    }
}
