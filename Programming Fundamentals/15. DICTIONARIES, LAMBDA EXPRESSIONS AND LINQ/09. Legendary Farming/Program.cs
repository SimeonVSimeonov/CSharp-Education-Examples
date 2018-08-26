using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shadowmourneObtained = false;
            bool valanyrObtained = false;
            bool dragonwrathObtained = false;
            string resource;
            int quantity = 0;
            string prize = "";
            SortedDictionary<string, int> resourcesPrimary = new SortedDictionary<string, int>();
            resourcesPrimary.Add("shards",0);
            resourcesPrimary.Add("motes", 0);
            resourcesPrimary.Add("fragments", 0);

            Dictionary<string, int> junk = new Dictionary<string, int>();

            while (shadowmourneObtained==false&&valanyrObtained==false&&dragonwrathObtained==false)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                for (int i = 0; i < input.Length; i+=2)
                {
                    resource = input[i+1].ToLower();
                    quantity = int.Parse(input[i]);
                    if (resourcesPrimary.ContainsKey(resource))
                    {
                        resourcesPrimary[resource] += quantity;
                    }
                    else if (!junk.ContainsKey(resource))
                    {
                        junk.Add(resource, quantity);
                    }
                    else
                    {
                        junk[resource] += quantity;
                    }
                    if (resourcesPrimary["shards"]>=250)
                    {
                        shadowmourneObtained = true;
                        prize = "Shadowmourne";
                        resourcesPrimary["shards"] -= 250;
                        break;
                    }
                    else if (resourcesPrimary["motes"] >=250)
                    {
                        dragonwrathObtained = true;
                        prize = "Dragonwrath";
                        resourcesPrimary["motes"] -= 250;
                        break;
                    }
                    else if (resourcesPrimary["fragments"]>=250)
                    {
                        valanyrObtained = true;
                        prize = "Valanyr";
                        resourcesPrimary["fragments"] -= 250;
                        break;
                    }
                }
            }
            Console.WriteLine($"{prize} obtained!");

            foreach (var metal in resourcesPrimary.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{metal.Key}: {metal.Value}");
            }
            foreach (var metal in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{metal.Key}: {metal.Value}");
            }           
        }
    }
}
