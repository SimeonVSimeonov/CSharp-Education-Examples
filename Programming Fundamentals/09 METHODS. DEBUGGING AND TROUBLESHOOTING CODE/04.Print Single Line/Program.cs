using System;

namespace _04.Print_Single_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSingleLine();
        }

        private static void PrintSingleLine()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
