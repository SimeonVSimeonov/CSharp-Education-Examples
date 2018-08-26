using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _04._Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Z]{2})([0-9]+\.[0-9]{1,2})([A-Za-z]+)\|";
            string input = Console.ReadLine();
            List<string> lines = new List<string>();   
            while (input!="end")
            {
                lines.Add(input);
                input = Console.ReadLine();
            }
            List<Match> myMatches = new List<Match>();
            foreach (var line in lines)
            {

                MatchCollection m = Regex.Matches(line, pattern);
                foreach (Match ThisMatch in m)
                {
                    myMatches.Add(ThisMatch);
                }
            }
            Dictionary<string, List<string>> weather = new Dictionary<string, List<string>>();
            foreach (var current in myMatches)
            {
                if (!weather.ContainsKey(current.Groups[1].Value))
                {
                    List<string> list = new List<string>();
                    list.Add(current.Groups[2].Value);
                    list.Add(current.Groups[3].Value);
                    weather.Add(current.Groups[1].Value, list);
                }
                else
                {
                    weather[current.Groups[1].Value].Clear();
                    weather[current.Groups[1].Value].Add(current.Groups[2].Value);
                    weather[current.Groups[1].Value].Add(current.Groups[3].Value);

                }
            }
            foreach (var pair in weather.OrderBy(x=>double.Parse(x.Value[0])))
            {
                Console.WriteLine($"{pair.Key} => {double.Parse(pair.Value[0]):F2} => {pair.Value[1]}");
            }
        }
    }
}
