using System;

namespace NumbersConcatenator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            string collector = "Numbers: ";

            for (int index = 1; index <= 200000; index++)

            {

                collector += index;

            }

            Console.WriteLine(collector.Substring(0, 100));

            Console.WriteLine(DateTime.Now);
        }
    }
}
