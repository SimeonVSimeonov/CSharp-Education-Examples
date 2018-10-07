using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            var numberClothes = int.Parse(Console.ReadLine());
            var colorsAndClothes = new Dictionary<string, HashSet<string>>();
            var duplicates = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberClothes; i++)
            {
                var input = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var color = input[0];
                var clothes = input[1].Split(",");

                if (!colorsAndClothes.ContainsKey(color))
                {
                    colorsAndClothes.Add(color, new HashSet<string>());
                    duplicates.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    colorsAndClothes[color].Add(item);
                    if (!duplicates[color].ContainsKey(item))
                    {
                        duplicates[color].Add(item, 0);
                    }
                    duplicates[color][item]++;
                }
            }

            var seek = Console.ReadLine().Split();
            foreach (var kvp in colorsAndClothes)
            {
                var color = kvp.Key;
                var set = kvp.Value;
                Console.WriteLine($"{color} clothes:");

                foreach (var item in set)
                {
                    var count = duplicates[color][item];
                    if (color == seek[0] && item == seek[1])
                    {
                        Console.WriteLine($"* {item} - {count} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {item} - {count}");
                }
            }
        }
    }
}
