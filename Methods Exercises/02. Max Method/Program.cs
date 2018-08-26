using System;

namespace _02._Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            if (GetMax(a,b) > c)
            {
                Console.WriteLine(GetMax(a,b));

            }
            else
            {
                Console.WriteLine(c);
            }

        }
        private static int GetMax (int a, int b)
        {
            if (a>b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
