using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] lines = Console.ReadLine()
                    .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = lines[j];
                }
            }

            long first = 0;
            long second = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                first += matrix[i, i];
                second += matrix[i, matrix.GetLength(1) - i - 1];
            }

            Console.WriteLine(Math.Abs(first-second));
        }
    }
}
