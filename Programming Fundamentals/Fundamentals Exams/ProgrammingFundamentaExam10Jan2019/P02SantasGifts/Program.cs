using System;
using System.Collections.Generic;
using System.Linq;

namespace P02SantasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandsCount = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var houses = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var house = 1;
            var currPos = 0;

            for (int i = 0; i < commandsCount; i++)
            {
                
                var tokes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokes.Length == 2)
                {
                    var command = tokes[0].Trim();
                    var steps = int.Parse(tokes[1]);
                   
                    switch (command)
                    {

                        case "Forward":

                            currPos = steps + currPos;

                            if (currPos >= houses.Count)
                            {
                                currPos -= steps;
                                continue;
                            }

                            house = houses[currPos];
                            currPos = houses.IndexOf(house);
                            houses.RemoveAt(currPos);

                            break;
                        case "Back":
                            currPos -= steps;

                            if (currPos < 0)
                            {
                                currPos += steps;
                                continue;
                            }


                            house = houses[currPos];
                            currPos = houses.IndexOf(house);
                            houses.Remove(house);
                            break;
                    }

                }
                if (tokes.Length == 3)
                {
                    if (currPos < 0 || currPos >= houses.Count)
                    {
                        continue;
                    }
                    var command = tokes[0].Trim();
                    var indx = int.Parse(tokes[1]);
                    
                    var houseOrSecondIndx = int.Parse(tokes[2]);

                    switch (command)
                    {
                        case "Gift":
                            if (indx < 0 || indx >= houses.Count)
                            {
                                continue;
                            }
                            houses.Insert(indx, houseOrSecondIndx);
                            currPos = indx;
                            break;

                        case "Swap":
                            if (houses.Contains(indx) && houses.Contains(houseOrSecondIndx))
                            {
                                var idx1 = houses.IndexOf(indx);
                                var idx2 = houses.IndexOf(houseOrSecondIndx);

                                var tmp = houses[idx1];
                                houses[idx1] = houses[idx2];
                                houses[idx2] = tmp;

                            }
                            break;
                    }

                }

            }

            Console.WriteLine($"Position: {currPos}");

            Console.WriteLine(string.Join(", ", houses));
        }
    }
}
