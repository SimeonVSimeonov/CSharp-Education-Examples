using System;

namespace Draw_а_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintHeaderRow(n);
            for (int i = 0; i < n-2; i++)
            {
                PrintMiddleRow(n);
            }
            PrintHeaderRow(n);
        }

        private static void PrintMiddleRow(int n)
        {
            Console.Write('-');
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(@"\/");
            }
            Console.WriteLine('-');
        }

        private static void PrintHeaderRow(int n)
        {
            Console.WriteLine(new string('-', 2*n));
        }
    }
}
