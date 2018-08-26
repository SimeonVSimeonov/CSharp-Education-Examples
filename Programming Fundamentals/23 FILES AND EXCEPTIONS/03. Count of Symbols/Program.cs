using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Count_of_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("input.txt").Replace(" ","").ToCharArray();
            var dict = new SortedDictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!dict.ContainsKey(symbol))
                {
                    dict[symbol] = 0;
                }

                dict[symbol]++;
            }
            var result = dict.OrderByDescending(x=>x.Value);
            File.WriteAllLines("output.txt", result.Select(x => $"{x.Key} {x.Value}"));
        }
    }
}
