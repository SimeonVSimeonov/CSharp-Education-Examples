using System;
using System.Linq;

namespace _03._Squares_in_Matrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int count = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    char current = matrix[i, j];
                    if (current == matrix[i,j+1]&&current==matrix[i+1,j]&&current==matrix[i+1,j+1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
