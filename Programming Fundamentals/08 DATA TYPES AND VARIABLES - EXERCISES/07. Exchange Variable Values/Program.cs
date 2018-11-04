using System;

namespace _07._Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int temp = a;
            a = b;
            b = temp;

            Console.WriteLine($"Before:\r\na = {temp}\r\nb = {a}");

            Console.WriteLine($"After:\r\na = {a}\r\nb = {temp}");
        }
    }
}
