using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Guitar
{
    class Program
    {
        private static int[] intervals;

        private static int max;

        static void Main()
        {
            string[] input = Console.ReadLine().Split(',').ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim();
            }
            intervals = input.Select(int.Parse).ToArray();
            int startDb = int.Parse(Console.ReadLine());
            max = int.Parse(Console.ReadLine());

            HashSet<int> actual = new HashSet<int>();
            actual.Add(startDb);
            HashSet<int> spare = new HashSet<int>();

            for (int i = 0; i < intervals.Length; i++)
            {
                foreach (var db in actual)
                {
                    int subRes = db - intervals[i];
                    if (subRes >= 0)
                    {
                        spare.Add(subRes);
                    }

                    int sumRes = db + intervals[i];
                    if (sumRes <= max)
                    {
                        spare.Add(sumRes);
                    }
                }

                actual = new HashSet<int>(spare);
                spare.Clear();
            }

            if (!actual.Any())
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine(actual.Max());
            }
        }
    }
}
