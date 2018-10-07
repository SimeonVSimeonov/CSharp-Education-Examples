using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            //Europe:
            //France->Paris
            //Germany->Hamburg, Danzig

            var continentData = new Dictionary<string, Dictionary<string, List<string>>>();
            string input;

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if (!continentData.ContainsKey(continent))
                {
                    continentData[continent] = new Dictionary<string, List<string>>();
                }
                if (!continentData[continent].ContainsKey(country))
                {
                    continentData[continent][country] = new List<string>();
                }

                continentData[continent][country].Add(city);
            }

            foreach (var contCountry in continentData)
            {
                var continentName = contCountry.Key;
                var countrys = contCountry.Value;
                Console.WriteLine($"{continentName}:");

                foreach (var coutry in countrys)
                {
                    var cities = coutry.Value;
                    Console.Write($"  {coutry.Key} -> ");
                    Console.WriteLine(string.Join(", ", cities));
                }
            }
        }
    }
}
