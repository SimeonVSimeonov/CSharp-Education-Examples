using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, int>();

            var fileWords = File.Open("..//..//..//..//files//words.txt", FileMode.Open);
            var fileText = File.Open("..//..//..//..//files//text.txt", FileMode.Open);
            var destinationPath = "..//..//..//..//files//result.txt";

            using (StreamReader reader = new StreamReader(fileWords))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();
                    if (!words.ContainsKey(line))
                    {
                        words.Add(line, 0);
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(fileText))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();
                    Regex regex = new Regex("[A-Za-z]+");

                    foreach (Match currentWord in regex.Matches(line))
                    {
                        if (words.ContainsKey(currentWord.Value))
                        {
                            words[currentWord.Value] += 1;
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                foreach (var word in words.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
