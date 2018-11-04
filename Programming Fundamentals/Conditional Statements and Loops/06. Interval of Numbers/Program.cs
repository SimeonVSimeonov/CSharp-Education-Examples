using System;

namespace _06._Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            if (start>end)
            {
                for (int i = end; i <= start; i++)
                {
                    Console.WriteLine(i);
                }
            }
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
