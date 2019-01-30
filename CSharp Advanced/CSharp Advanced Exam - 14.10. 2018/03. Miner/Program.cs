using System;

namespace _03._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] moveCommands = Console.ReadLine().Split();
            string[,] field = new string[fieldSize, fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                var items = Console.ReadLine().Split();
                for (int j = 0; j < items.Length; j++)
                {
                    field[i, j] = items[j];
                }
            }


        }
    }
}
