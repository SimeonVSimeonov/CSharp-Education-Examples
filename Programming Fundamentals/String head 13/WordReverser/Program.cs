using System;
using System.Text;

namespace WordReverser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "EM edit";
            string reversed = ReversedText(text);
            Console.WriteLine(reversed);
        }

        private static string ReversedText(string text)
        {
            StringBuilder strBuild = new StringBuilder();
            for (int i = text.Length-1; i >= 0; i--)
            {
                strBuild.Append(text[i]);
            }
            return strBuild.ToString();
        }
    }
}
