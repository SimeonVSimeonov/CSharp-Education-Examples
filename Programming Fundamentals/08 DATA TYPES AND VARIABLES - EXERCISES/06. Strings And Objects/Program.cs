using System;

namespace _06._Strings_And_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = "Hello";
            var string2 = "World";
            string concat = string.Concat(string1," ", string2);
            Console.WriteLine(concat);
        }
    }
}
