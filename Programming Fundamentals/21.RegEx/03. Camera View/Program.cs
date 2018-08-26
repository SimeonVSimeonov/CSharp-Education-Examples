using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int toSkip = numbers[0];
            int toTake = numbers[1];

            string input = Console.ReadLine();
            string pattern = @"\|<([\w]{" + toSkip + @"})([\w]{0," + toTake + @"})";

            MatchCollection myMatches = Regex.Matches(input, pattern);
            List<string> result = new List<string>();

            foreach (Match item in myMatches)
            {
                result.Add(item.Groups[2].Value);
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
