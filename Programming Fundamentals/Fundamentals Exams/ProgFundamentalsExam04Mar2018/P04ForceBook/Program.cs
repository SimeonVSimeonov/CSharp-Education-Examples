using System;
using System.Collections.Generic;
using System.Linq;

namespace P04ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            var usersPool = new Dictionary<string, string>();
            var sides = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    var tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var forceSide = tokens[0];
                    var forceUser = tokens[1];

                    if (!usersPool.ContainsKey(forceUser))
                    {
                        usersPool.Add(forceUser, forceSide);
                    }

                }
                else
                {
                    var tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var forceUser = tokens[0];
                    var forceSide = tokens[1];


                    if (usersPool.ContainsKey(forceUser))
                    {
                        usersPool.Remove(forceUser);
                        usersPool.Add(forceUser, forceSide);
                    }
                    else
                    {
                        usersPool.Add(forceUser, forceSide);

                        
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }


            }

            foreach (var item in usersPool)
            {
                if (!sides.ContainsKey(item.Value))
                {
                    sides.Add(item.Value, new List<string>());
                }
                sides[item.Value].Add(item.Key);
            }

            foreach (var item in sides.Keys.OrderBy(x => x))
            {
                Console.WriteLine($"Side: {item}, Members: {sides[item].Count}");
                foreach (var user in sides[item].OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
