using System;

namespace _13._Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            var sum = 0;
            var counter = 0;

            for (int i = m; i >= n; i--)
            {
                for (int j = n; j <=m; j++)
                {
                    counter++;
                    sum = i + j;
                    if (sum == magicNum)
                    {
                        Console.WriteLine($"Number found! {i} + {j} = {magicNum}");
                        return;
                    }
      
                }
               
            }
            Console.WriteLine($"{counter} combinations - neither equals {magicNum}");           
        }
    }
}
