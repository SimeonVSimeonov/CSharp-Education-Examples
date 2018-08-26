using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("words.txt").ToLower().Split();
            string[] text = File.ReadAllText("text.txt").ToLower()
                .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                wordCount[word] = 0;
            }
            foreach (var word in text)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
            }
            wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(y=>y.Key,y=>y.Value);
            File.WriteAllText("output.txt","");
            foreach (KeyValuePair<string,int> pair in wordCount)
            {
                File.AppendAllText("output.txt", $"{pair.Key} - {pair.Value}\r\n");
            }
        }
    }
}
