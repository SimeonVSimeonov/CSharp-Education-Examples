using System;
using System.Linq;

namespace _02._Parking_Feud
{
    class ParkingFeud
    {
        static int rows = 0;
        static int cols = 0;

        static void Main(string[] args)
        {
            /* 5 4
               4
               C1 B2 D3 B2
               B1 A1 D2 D2
               D1 C3 D5 D5 */

            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = size[0];
            cols = size[1];

            int entrance = int.Parse(Console.ReadLine());
            int totalSteps = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string samSpot = input[entrance - 1];

                bool isParked = true;

                int currentSamSteps = GetSteps(entrance, samSpot);

                for (int i = 0; i < input.Length; i++)
                {
                    bool isSameSpot = input[i] == samSpot;
                    bool isDifferentRow = i + 1 != entrance;

                    if (isSameSpot && isDifferentRow)
                    {
                        int enemySteps = GetSteps(i + 1, input[i]);
                        if (enemySteps < currentSamSteps)
                        {
                            totalSteps += currentSamSteps * 2;
                            isParked = false;
                            break;
                        }
                    }
                }

                if (isParked)
                {
                    totalSteps += currentSamSteps;
                    Console.WriteLine($"Parked successfully at {samSpot}.");
                    Console.WriteLine($"Total Distance Passed: {totalSteps}");
                    return;
                }
            }
        }

        private static int GetSteps(int inputRow, string samSpot)
        {
            int targetRow = int.Parse(samSpot.Substring(1));
            int targetCol = samSpot[0] - 'A' + 1;

            int currrentSteps = 0;
            bool isRight = true;

            while (targetRow != inputRow && targetRow - 1 != inputRow)
            {
                currrentSteps += cols + 3;
                if (inputRow > targetRow)
                {
                    inputRow--;
                }
                if (inputRow < targetRow)
                {
                    inputRow++;
                }

                isRight = !isRight;
            }

            if (isRight)
            {
                currrentSteps += targetCol;
            }
            else
            {
                currrentSteps += cols - targetCol + 1;
            }

            return currrentSteps;
        }
    }
}
