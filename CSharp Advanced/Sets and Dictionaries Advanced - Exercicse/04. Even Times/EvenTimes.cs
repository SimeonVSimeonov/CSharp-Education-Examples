using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var collection = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (!collection.ContainsKey(input))
                {
                    collection.Add(input, 0);
                }
                collection[input]++;
            }

            foreach (var item in collection)
            {
                int num = item.Key;
                int count = item.Value;
                if (count % 2 == 0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
