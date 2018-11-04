using System;

namespace _12._Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int sumMax = int.Parse(Console.ReadLine());

            var sum = 0;
            var counter = 0;

            for (int i = n ; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    counter++;
                    sum += i * j * 3;

                    if (sum>=sumMax)
                    {
                        Console.WriteLine($"{counter} combinations\r\nSum: {sum} >= {sumMax}");
                        return;
                    }
                }
                
            }
            Console.WriteLine($"{counter} combinations\r\nSum: {sum}");
        }
    }
}
