using System;
using System.Collections.Generic;
using System.Linq;

namespace P04IronGirder
{
    class Program
    {
        static void Main(string[] args)
        {

            var ironGirder = new Dictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "Slide rule")
            {
                var tokens = input.Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var townName = tokens[0];
                var timeOrAmbush = tokens[1];
                var passengersCount = int.Parse(tokens[2]);
                var time = 0;

                if (int.TryParse(timeOrAmbush, out time))
                {
                    var pass = 0;

                    if (!ironGirder.ContainsKey(townName))
                    {
                        ironGirder.Add(townName, new Dictionary<string, int>());
                    }

                    if (ironGirder[townName].ContainsKey(0.ToString()))
                    {
                        pass = ironGirder[townName][0.ToString()];
                        ironGirder[townName].Remove(0.ToString());

                    }

                    ironGirder[townName].Add(time.ToString(), passengersCount + pass);
                }
                else
                {

                    if (ironGirder.ContainsKey(townName))
                    {
                       
                        var data = input.Split("->");
                        var currPass = int.Parse(data[1]);
                        int allPass = 0;
                        
                            
                        foreach (var item in ironGirder[townName])
                        {
                            allPass += item.Value;
                            int newValue = allPass - currPass;  
                            ironGirder[townName] = new Dictionary<string, int>();
                            ironGirder[townName].Add(0.ToString(), newValue);
                        }

                    }
                    else
                    {
                        continue;
                    }
                }

            }

            foreach (var item in ironGirder.OrderBy(x => x.Value.Keys.Min()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> Time: {item.Value.Keys.Min()} -> Passengers: {item.Value.Values.Sum()}");
            }

        }
    }
}
