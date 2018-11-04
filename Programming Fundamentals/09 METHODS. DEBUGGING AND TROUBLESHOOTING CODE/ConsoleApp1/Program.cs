using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers(0,1000);
        }

        private static void PrintNumbers(int start,int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("{0}",i);
            }
        }
    }
}
