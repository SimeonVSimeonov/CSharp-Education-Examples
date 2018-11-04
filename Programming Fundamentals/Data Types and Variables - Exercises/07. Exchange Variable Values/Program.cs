using System;

namespace _07._Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;
            var b = 10;
            Console.WriteLine($"Before:\r\na = {a}\r\nb = {b}");
            var c = a;
            a = b;
            b = c;
            Console.WriteLine($"After:\r\na = {a}\r\nb = {b}");
        }
    }
}
