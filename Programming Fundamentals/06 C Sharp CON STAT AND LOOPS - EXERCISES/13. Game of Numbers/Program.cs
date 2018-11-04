using System;

namespace _13._Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = m; i >= n; i--)
            {
                for (int j = m; j >= n; j--)
                {
                    if (i+j==magic)
                    {
                        Console.WriteLine($"Number found! {i} + {j} = {magic}");
                        return;
                    }
                    count++;
                }
            }
            Console.WriteLine($"{count} combinations - neither equals {magic}");
        }
    }
}
