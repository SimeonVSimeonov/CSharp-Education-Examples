using System;
using System.Linq;

namespace _07._Lego_Blocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[][] jaggedOne = new int[count][];
            int[][] jaggedTwo = new int[count][];
            int[][] result = new int[count][];

            for (int i = 0; i < count; i++)
            {
                jaggedOne[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < count; i++)
            {
                jaggedTwo[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < count; i++)
            {
                result[i] = new int[jaggedOne[i].Length + jaggedTwo[i].Length];
                Array.Reverse(jaggedTwo[i]);

                for (int j = 0; j < jaggedOne[i].Length; j++)
                {
                    result[i][j] = jaggedOne[i][j];
                }

                for (int j = 0; j < result[i].Length-jaggedOne[i].Length; j++)
                {
                    result[i][j + jaggedOne[i].Length] = jaggedTwo[i][j];
                }
            }

            int length = result[0].Length;

            if (result.Any(a => a.Length !=length))
            {
                Console.WriteLine($"The total number of cells is: {result.Sum(a => a.Length)}");
            }
            else
            {
                Print(result);
            }
        }

        private static void Print(int[][] result)
        {
            foreach (var item in result)
            {
                Console.WriteLine($"[{String.Join(", ", item)}]");
            }
        }
    }
}
