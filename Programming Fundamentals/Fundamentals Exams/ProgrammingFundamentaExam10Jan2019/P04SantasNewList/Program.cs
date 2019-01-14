using System;
using System.Collections.Generic;
using System.Linq;

namespace P04SantasNewList
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var children = new Dictionary<string, int>();
            var presents = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToList();
                var childName = tokens[0];

                if (tokens.Count == 2)
                {
                    childName = tokens[1];
                    if (children.ContainsKey(childName))
                    {
                        children.Remove(childName);
                    }
                }
                else
                {
                    var typeOfPresent = tokens[1];
                    var amount = int.Parse(tokens[2]);



                    if (!children.ContainsKey(childName))
                    {
                        children.Add(childName, 0);
                    }
                    children[childName] += amount;

                    if (!presents.ContainsKey(typeOfPresent))
                    {
                        presents.Add(typeOfPresent, 0);
                    }
                    presents[typeOfPresent] += amount;

                }
                ;
            }

            Console.WriteLine("Children:");

            foreach (var child in children.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{child.Key} -> {child.Value}");
            }

            Console.WriteLine("Presents:");

            foreach (var present in presents)
            {
                Console.WriteLine($"{present.Key} -> {present.Value}");
            }
        }
    }
}
