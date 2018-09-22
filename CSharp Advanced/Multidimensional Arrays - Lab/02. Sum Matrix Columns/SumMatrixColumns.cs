using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var colElements = Console.ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            //3, 3
            //1 2 3
            //4 5 6
            //7 8 9

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
