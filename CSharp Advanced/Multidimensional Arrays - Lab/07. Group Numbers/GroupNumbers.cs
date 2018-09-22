using System;
using System.Linq;

namespace _07._Group_Numbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] jagged = new int[3][];
            int[] sizes = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                sizes[Math.Abs(numbers[i] % 3)]++;
            }

            for (int i = 0; i < sizes.Length; i++)
            {
                jagged[i] = new int[sizes[i]];
            }

            int[] indices = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = Math.Abs(numbers[i] % 3);
                jagged[remainder][indices[remainder]++] = numbers[i];
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jagged[i]));
            }
        }
    }
}
