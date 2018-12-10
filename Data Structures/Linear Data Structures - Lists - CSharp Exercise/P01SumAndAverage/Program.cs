using System;
using System.Collections.Generic;
using System.Linq;



public class Program
{
    public static void Main(string[] args)
    {
        List<int> nums = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"Sum={(nums.Count == 0 ? 0 : nums.Sum())}; Average={(nums.Count == 0 ? 0 : nums.Average()):F2}");
    }
}

