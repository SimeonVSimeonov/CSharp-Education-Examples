using System;

namespace Quote_Index_Of
{
    class Program
    {
        static void Main(string[] args)
        {
            string quote = "The main intent of the \"Intro C#\"" +
                                " book is to introduce the C# programming to newbies.";

            string keyWord = "C#";
            int index = keyWord.IndexOf("C#");

            while (index!=-1)
            {
                Console.WriteLine("{0} found at index: {1}", keyWord, index);
                index = quote.IndexOf(keyWord, index + 1);
            }
        }
    }
}
