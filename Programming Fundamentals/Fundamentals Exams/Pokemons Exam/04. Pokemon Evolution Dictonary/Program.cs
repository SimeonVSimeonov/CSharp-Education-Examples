using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Pokemon_Evolution_Dictonary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[]
            { '-', '>', ' ' }, StringSplitOptions
            .RemoveEmptyEntries)
            .ToArray();
            var name = "";
            var evoltion = "";
            var pokemons = new Dictionary<string, List<string>>();

            while (input[0] != "wubbalubbadubdub")
            {
                if (input.Length > 1)
                {

                    name = input[0];
                    evoltion = input[1] + " <-> " + input[2];
                    if (!pokemons.ContainsKey(name))
                    {
                        var currentList = new List<string>() { evoltion };
                        pokemons.Add(name, currentList);
                    }
                    else
                    {
                        pokemons[name].Add(evoltion);
                    }
                }
                else
                {
                    name = input[0];
                    if (pokemons.ContainsKey(name))
                    {
                        Console.WriteLine($"# {name}");
                        foreach (var ev in pokemons[name])
                        {
                            Console.WriteLine($"{ev}");
                        }
                    }
                }

                input = Console.ReadLine().Split(new char[]
                     { '-', '>', ' ' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .ToArray();

            }
            foreach (var pair in pokemons)
            {
                Console.WriteLine($"# {pair.Key}");
                foreach (var ev in pair.Value.OrderByDescending(x => int.Parse(x.Split(new char[]
                { '<', ' ', '>', '-' }, StringSplitOptions
                    .RemoveEmptyEntries)
                    .Skip(1)
                    .First())))
                {
                    Console.WriteLine($"{ev}");
                }
            }
        }
    }
}
