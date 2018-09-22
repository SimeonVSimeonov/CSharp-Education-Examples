using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            var matrixRows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[i] = currentRow;
            }

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0]?.ToLower() != "end")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0 || 
                    row > matrix.Length - 1 || 
                    col < 0 || 
                    col > matrix[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (input[0]?.ToLower())
                {
                    case "add":
                        matrix[row][col] += value;
                        break;
                    case "subtract":
                        matrix[row][col] -= value;
                        break;
                }

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
