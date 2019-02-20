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
            var samRow = 0;
            var samCol = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                var items = Console.ReadLine().Split();
                for (int col = 0; col < items.Length; col++)
                {
                    field[row, col] = items[col];

                    if (field[row, col] == "s")
                    {
                        samRow = row;
                        samCol = col;
                        break;
                    }
                }
            }

            for (int i = 0; i < moveCommands.Length; i++)
            {
                var moveToRow = 0;
                var moveToCol = 0;

                switch (moveCommands[i])
                {
                    case "up":
                        moveToRow = samRow - 1;
                        moveToCol = samCol;
                        break;
                    case "right":
                        moveToRow = samRow;
                        moveToCol = samCol + 1;
                        break;
                    case "left":
                        moveToRow = samRow;
                        moveToCol = samCol - 1;
                        break;
                    case "down":
                        moveToRow = samRow + 1;
                        moveToCol = samCol;
                        break;
                }

                if (isValidMove(fieldSize, moveToRow, moveToCol))
                {
                    var entity = field[moveToRow, moveToCol];

                    switch (entity)
                    {
                        case "*":
                            field[moveToRow, moveToCol] = "s";
                            field[samRow, samCol] = "*";
                            samRow = moveToRow;
                            samCol = moveToCol;
                            break;
                        case "c":
                            field[moveToRow, moveToCol] = "s";
                            field[samRow, samCol] = "*";
                            samRow = moveToRow;
                            samCol = moveToCol;
                            break;
                        case "e":
                            Console.WriteLine($"Game over! ({moveToRow}, {moveToCol})");
                            break;
                    }
                }

                if (allCoalsGather(field))
                {
                    Console.WriteLine($"You collected all coals! ({samRow}, {samCol})");
                }
            }

        }

        private static bool allCoalsGather(string[,] field)
        {
            throw new NotImplementedException();
        }

        private static bool isValidMove(int fieldSize, int moveToRow, int moveToCol)
        {
            if (moveToRow <= fieldSize - 1 && moveToRow > 0 && moveToCol <= fieldSize - 1 && moveToCol > 0)
            {
                return true;
            }

            return false;
        }
    }
}
