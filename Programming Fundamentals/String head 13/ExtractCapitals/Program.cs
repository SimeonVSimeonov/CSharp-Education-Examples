using System;
using System.Text;

namespace ExtractCapitals
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "asdksdmcmW ;lsdmvmOdsl, Wlsdmvm";
            string capsLetter = ExtractCapitals(text);
            Console.WriteLine(capsLetter);
        }

        private static string ExtractCapitals(string text)
        {
            StringBuilder upper = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (char.IsUpper(ch))
                {
                    upper.Append(ch);
                }
            }
            return upper.ToString();
        }
    }
}
