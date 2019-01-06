using System;
using System.Collections.Generic;
using System.Linq;

namespace IronGirder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> passengers = new Dictionary<string, int>();
            Dictionary<string, int> times = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Slide rule")
            {
                string[] data = input.Split(":");

                string town = data[0];
                string[] info = data[1].Split("->");

                int numberOfPassengers = int.Parse(info[1]);

                if (info[0] == "ambush")
                {
                    if (times.ContainsKey(town))
                    {
                        times[town] = 0;
                        passengers[town] -= numberOfPassengers;
                    }
                }
                else
                {
                    int currentTime = int.Parse(info[0]);

                    if (times.ContainsKey(town) == false)
                    {
                        times.Add(town, currentTime);
                        passengers.Add(town, numberOfPassengers);
                    }
                    else
                    {
                        passengers[town] += numberOfPassengers;

                        if (times[town] > currentTime || times[town] == 0)
                        {
                            times[town] = currentTime;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var pair in times.OrderBy(p => p.Value).ThenBy(p => p.Key))
            {
                string town = pair.Key;

                if (times[town] == 0 || passengers[town] == 0)
                {
                    continue;
                }

                Console.WriteLine($"{town} -> Time: {pair.Value} -> Passengers: {passengers[town]}");
            }
        }
    }
}