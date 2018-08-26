using System;

namespace _17._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            for (char i = (char)first; i <= (char)second; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
