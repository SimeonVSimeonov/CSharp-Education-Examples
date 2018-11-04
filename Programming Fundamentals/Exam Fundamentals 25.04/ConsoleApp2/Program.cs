using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abcde";

            str = str.Replace('a', 'e');
            Console.WriteLine(str);
        }
    }
}
