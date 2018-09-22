using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            var sum = 0;
            for (int row = 0; row < size; row++)
            {
                var inputElements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < inputElements.Length; col++)
                {
                    matrix[row, col] = inputElements[col];
                    if (row == col)
                    {
                        sum += inputElements[col];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
