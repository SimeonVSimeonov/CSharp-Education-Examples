using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)

        {
            PrintNumbers();
        }

        static void PrintNumbers(int start = 0, int end = 10)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write("{0} ", i);
            }
        }

    }
}
