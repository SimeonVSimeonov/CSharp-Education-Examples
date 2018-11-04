using System;

namespace Problem_10._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{num} X {times} = {times * num}");
                times++;
            } while (times<=10);
        }
    }
}
