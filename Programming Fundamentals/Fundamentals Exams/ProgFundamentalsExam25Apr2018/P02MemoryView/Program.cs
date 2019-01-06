using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02MemoryView
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            List<string> words = new List<string>();
            while (input != "Visual Studio crash")
            {
                result += input + " ";
                input = Console.ReadLine();
            }

            string pattern = @"32656 19759 32763 0 (\d) 0";
            Match match = Regex.Match(result, pattern);
            while (match.Success)
            {
                int width = int.Parse(match.Groups[1].Value);
                string inPattern = "32656 19759 32763 0 " + width + " 0 ((\\d+ ){" + width + "})";
                Match inMatch = Regex.Match(result, inPattern);
                string wholeMatch = inMatch.Groups[0].Value;
                string word = ReadWord(inMatch.Groups[1].Value);
                words.Add(word);
                result = result.Replace(wholeMatch, "");
                match = match.NextMatch();
            }

            Console.WriteLine(string.Join("\n", words));
        }

        private static string ReadWord(string value)
        {
            string word = string.Empty;
            string[] tokens = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in tokens)
            {
                word += (char)int.Parse(item);
            }

            return word;
        }
    }
}
