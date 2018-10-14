using System;

namespace _02._Knight_Game
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jaggedArray = new char[rows][];

            GetJaggedArray(jaggedArray);

            int targetRow = 0;
            int targetCol = 0;

            int removedKnights = 0;

            while (true)
            {
                int maxAttacked = 0;

                for (int row = 0; row < jaggedArray.Length; row++)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        int attacked = 0;

                        if (jaggedArray[row][col] == 'K')
                        {
                            //up left
                            if (IsInside(jaggedArray, row - 2, col - 1) && jaggedArray[row - 2][col - 1] == 'K')
                            {
                                attacked++;
                            }

                            //up right
                            if (IsInside(jaggedArray, row - 2, col + 1) && jaggedArray[row - 2][col + 1] == 'K')
                            {
                                attacked++;
                            }

                            //down left
                            if (IsInside(jaggedArray, row + 2, col - 1) && jaggedArray[row + 2][col - 1] == 'K')
                            {
                                attacked++;
                            }

                            //down right
                            if (IsInside(jaggedArray, row + 2, col + 1) && jaggedArray[row + 2][col + 1] == 'K')
                            {
                                attacked++;
                            }

                            //left up
                            if (IsInside(jaggedArray, row - 1, col - 2) && jaggedArray[row - 1][col - 2] == 'K')
                            {
                                attacked++;
                            }

                            //left down
                            if (IsInside(jaggedArray, row + 1, col - 2) && jaggedArray[row + 1][col - 2] == 'K')
                            {
                                attacked++;
                            }

                            //right up
                            if (IsInside(jaggedArray, row - 1, col + 2) && jaggedArray[row - 1][col + 2] == 'K')
                            {
                                attacked++;
                            }

                            //right down
                            if (IsInside(jaggedArray, row + 1, col + 2) && jaggedArray[row + 1][col + 2] == 'K')
                            {
                                attacked++;
                            }
                        }
                        if (attacked>maxAttacked)
                        {
                            maxAttacked = attacked;
                            targetRow = row;
                            targetCol = col;
                        }
                    }
                }

                if (maxAttacked>0)
                {
                    jaggedArray[targetRow][targetCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool IsInside(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray.Length;
        }

        private static void GetJaggedArray(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
