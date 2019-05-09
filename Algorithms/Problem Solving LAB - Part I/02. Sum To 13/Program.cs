using System;
using System.Linq;

namespace _02._Sum_To_13
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] input = Console.ReadLine()
                 .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(item => decimal.Parse(item))
                 .ToArray();

            if (input[0] + input[1] + input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (input[0] - input[1] + input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (input[0] - input[1] - input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (input[0] + input[1] - input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-input[0] + input[1] - input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-input[0] - input[1] - input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-input[0] - input[1] + input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-input[0] + input[1] + input[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
