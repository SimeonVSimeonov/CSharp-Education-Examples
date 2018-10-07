using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var firstLen = firstLine[0];
            var secondLen = firstLine[1];

            for (int i = 0; i < firstLen; i++)
            {
                var input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }

            for (int i = 0; i < secondLen; i++)
            {
                var input = int.Parse(Console.ReadLine());
                secondSet.Add(input);
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();

        }
    }
}
