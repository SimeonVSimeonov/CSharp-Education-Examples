using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Count_Numbers_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            nums.Sort();
            var pos = new int[1001];

            foreach (var num in nums)
            {
                pos[num]++;
            }
            for (int i = 0; i < pos.Length; i++)
            {
                if (pos[i]>0)
                {
                    Console.WriteLine($"{i} -> {pos[i]}");

                }
            }
        }
    }
}
