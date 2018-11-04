using System;

namespace Problem_9._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int times = 1;
            while (times<=10)
            {
                Console.WriteLine($"{num} X {times} = {times*num}");
                times++;
            }
        }
    }
}
