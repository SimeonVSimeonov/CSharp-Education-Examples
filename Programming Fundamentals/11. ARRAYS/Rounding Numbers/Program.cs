using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] numRounded = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                numRounded[i] = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{nums[i]} -> {numRounded[i]}");
            }
        }
    }
}