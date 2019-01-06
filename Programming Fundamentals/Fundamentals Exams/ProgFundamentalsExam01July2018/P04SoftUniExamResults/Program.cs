using System;
using System.Collections.Generic;
using System.Linq;

namespace P04SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = new Dictionary<string, List<int>>();
            var languages = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                var tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];

                if (tokens.Length == 2)
                {
                    if (usernames.ContainsKey(name))
                    {
                        usernames.Remove(name);
                    }
                }
                else
                {
                    var language = tokens[1];
                    var points = int.Parse(tokens[2]);
                    var count = 1;

                    if (!usernames.ContainsKey(name))
                    {
                        usernames.Add(name, new List<int>());
                    }
                    usernames[name].Add(points);

                    if (!languages.ContainsKey(language))
                    {
                        languages.Add(language, count);
                    }
                    else
                    {
                        languages[language] += count;

                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var item in usernames.OrderByDescending(r => r.Value.Max()).ThenBy(r => r.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value.Max()}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in languages.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
