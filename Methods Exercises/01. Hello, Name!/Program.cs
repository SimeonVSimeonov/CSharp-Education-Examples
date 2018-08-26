using System;

namespace _01._Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = EnterName();
            HelloName(name);
        }

        private static void HelloName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        private static string EnterName()
        {
            return Console.ReadLine();
        }
    }
}
