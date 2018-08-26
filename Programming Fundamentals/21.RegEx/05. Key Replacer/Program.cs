using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _05._Key_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Za-z]+)([\|\\<])(.*)([\|\\<])([A-Za-z]+)";
            string input = Console.ReadLine();
            Match myMatch = Regex.Match(input, pattern);
            string start = myMatch.Groups[1].Value;
            string end = myMatch.Groups[5].Value;
            string input2 = Console.ReadLine();
            string pattern2 = $@"{start}(.*?){end}";
            StringBuilder stringBuilder = new StringBuilder();

            MatchCollection result = Regex.Matches(input2, pattern2);
            foreach (Match m in result)
            {
                stringBuilder.Append(m.Groups[1].Value);
            }
            Console.WriteLine(stringBuilder.ToString().Length == 0? "Empty result" : stringBuilder.ToString());
        }
    }
}
