using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        Dictionary<int, int> occurrences = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (!occurrences.ContainsKey(numbers[i]))
            {
                occurrences.Add(numbers[i], 0);
            }

            occurrences[numbers[i]] += 1;
        }

        foreach (var item in occurrences.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{item.Key} -> {item.Value} times");
        }
    }
}

