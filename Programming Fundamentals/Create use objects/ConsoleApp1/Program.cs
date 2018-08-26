using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int sum = 0;

            //int startTime = Environment.TickCount;

            //for (int i = 0; i < 10000000; i++)
            //{
            //    sum++;
            //}

            //int endTime = Environment.TickCount;
            //Console.WriteLine("The time elapsed is {0} sec.",
            //    (endTime - startTime) / 1000.0);

            Random rand = new Random();

            for (int number = 1; number <= 6; number++)

            {

                int randomNumber = rand.Next(100) + 1;

                Console.Write("{0} ", randomNumber);

            }
        }
    }
}
