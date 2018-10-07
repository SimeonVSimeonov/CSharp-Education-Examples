using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dict = new SortedDictionary<char,int>();

            foreach (var symbol in input)
            {
                if (!dict.ContainsKey(symbol))
                {
                    dict.Add(symbol, 0);
                }
                dict[symbol]++;
            }

            foreach (var item in dict)
            {
                var symbol = item.Key;
                var count = item.Value;
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
