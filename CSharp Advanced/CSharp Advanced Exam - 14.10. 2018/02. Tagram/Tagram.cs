using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {

            var tagrams = new Dictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {

                string[] inputArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0].Contains("ban"))
                {
                    var remove = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var nameToRemove = remove[1];
                    if (tagrams.ContainsKey(nameToRemove))
                    {
                        tagrams.Remove(nameToRemove);
                    }
                }

                else
                {
                    var username = inputArgs[0];
                    var tag = inputArgs[1];
                    var likes = int.Parse(inputArgs[2]);

                    if (!tagrams.ContainsKey(username))
                    {
                        tagrams.Add(username, new Dictionary<string, int>());
                    }
                    if (!tagrams[username].ContainsKey(tag))
                    {
                        tagrams[username].Add(tag, likes);
                    }

                   // tagrams.OrderByDescending(x => x.Value);
                }
                tagrams = tagrams.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);

            }

            foreach (var item in tagrams)
            {
                Console.WriteLine(item.Key);
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"- {kvp.Key}: {kvp.Value}");

                }
            }
        }
    }
}