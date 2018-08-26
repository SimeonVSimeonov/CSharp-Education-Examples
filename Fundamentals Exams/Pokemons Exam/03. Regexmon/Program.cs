using System;
using System.Text.RegularExpressions;

namespace _03._Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string didiPatern = @"[^a-zA-Z-]+";
            string bojoPatern = @"[a-zA-Z]+-[a-zA-Z]+";
            var round = 1;

            while (true)
            {
                if (round%2==1)
                {
                    if (!Regex.IsMatch(input, didiPatern))
                    {
                        return;
                    }
                    else
                    {
                        Match current = Regex.Match(input, didiPatern);
                        input = input.Substring(current.Index + current.Length);
                        Console.WriteLine(current.ToString());
                    }
                }
                else
                {
                    if (!Regex.IsMatch(input, bojoPatern))
                    {
                        return;
                    }
                    else
                    {
                        Match current = Regex.Match(input, bojoPatern);
                        input = input.Substring(current.Index + current.Length);
                        Console.WriteLine(current.ToString());
                    }
                }
                round++;
            }

        }
    }
}
