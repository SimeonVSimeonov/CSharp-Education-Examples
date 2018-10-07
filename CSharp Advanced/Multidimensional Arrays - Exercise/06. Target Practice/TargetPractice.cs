﻿using System;
using System.Linq;

namespace _06._Target_Practice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            string snake = Console.ReadLine();
            int counter = 0;
            bool goLeft = true;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                int j = goLeft ? matrix.GetLength(1) - 1 : 0;

                for (; j >= 0 && j < matrix.GetLength(1); j = goLeft ? j - 1 : j + 1)
                {
                    matrix[i, j] = snake[counter++ % snake.Length];
                }

                goLeft = !goLeft;
            }

            int[] shotData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = shotData[0];
            int targetCol = shotData[1];
            int radius = shotData[2];

            for (int i = targetRow - radius; i <= targetRow + radius; i++)
            {
                for (int j = targetCol - radius; j <= targetCol + radius; j++)
                {
                    if (InRange(i, j, targetRow, targetCol, radius, matrix))
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                for (int i = matrix.GetLength(0) - 1; i > 0; i--)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == ' ')
                        {
                            char temp = matrix[i, j];
                            matrix[i, j] = matrix[i - 1, j];
                            matrix[i - 1, j] = temp;
                        }
                    }
                }
            }

            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool InRange(int i, int j, int targetRow, int targetCol, int radius, char[,] matrix)
        {
            if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
            {
                return false;
            }
            if (Math.Sqrt(Math.Pow(targetRow - i, 2) + Math.Pow(targetCol - j, 2)) <= radius)
            {
                return true;
            }

            return false;
        }
    }
}
