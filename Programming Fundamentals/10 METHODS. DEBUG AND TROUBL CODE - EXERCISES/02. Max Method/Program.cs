using System;

namespace _02._Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            GetMax(num1, num2);
            int bigger = Math.Max(GetMax(num1,num2), num3);
            Console.WriteLine(bigger);
        }
        static int GetMax( int num1, int num2)
        {
            int max = Math.Max(num1, num2);

            return max;
        }
    }
}
