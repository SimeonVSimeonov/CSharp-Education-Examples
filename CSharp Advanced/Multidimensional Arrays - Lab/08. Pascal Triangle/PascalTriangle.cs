using System;

namespace _08._Pascal_Triangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] jagged = new long[size][];

            for (int i = 1; i <= size; i++)
            {
                jagged[i - 1] = new long[i];
                jagged[i - 1][0] = 1;
                jagged[i - 1][jagged[i - 1].Length - 1] = 1;
            }

            //1 
            //1 1
            //1 2 1
            //1 3 3 1


            for (int i = 2; i < size; i++)
            {
                for (int j = 1; j < jagged[i].Length - 1; j++)
                {
                    jagged[i][j] = jagged[i - 1][j - 1] + jagged[i - 1][j];
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }
    }
}
