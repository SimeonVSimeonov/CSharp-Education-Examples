using System;
using System.Linq;

namespace _10._Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = i; j < arry.Length-1; j++)
                {
                    if (Math.Abs(arry[i] - arry[j+1]) == diff)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
