using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mailbook = new Dictionary<string, string>();
            string name = "";
            string email = "";
            string comm = Console.ReadLine();

            while (comm!="stop")
            {
                name = comm;
                email = Console.ReadLine();
                if (!mailbook.ContainsKey(name))
                {
                    mailbook.Add(name, email);
                }
                comm = Console.ReadLine();
            }
            foreach (var pair in mailbook.Where(x => !x.Value.EndsWith(".us") && !x.Value.EndsWith(".uk")))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
