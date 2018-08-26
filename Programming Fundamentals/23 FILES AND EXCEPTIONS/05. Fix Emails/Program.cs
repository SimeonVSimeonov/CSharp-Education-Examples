using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] data = File.ReadAllLines("input.txt");
            Dictionary<string, string> allowedEmails = new Dictionary<string, string>();

            for (int i = 1; i < data.Length; i += 2)
            {
                if (data[i].EndsWith("uk") || data[i].EndsWith("us"))
                {
                    continue;
                }

                allowedEmails[data[i - 1]] = data[i];
            }

            string[] result = allowedEmails
                .Select(x => $"{x.Key} -> {x.Value}")
                .ToArray();

            File.WriteAllLines("output.txt", result);

        }
    }
}
