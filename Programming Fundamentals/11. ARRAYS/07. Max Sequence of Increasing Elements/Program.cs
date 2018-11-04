using System;
using System.Linq;

namespace _07._Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 1;
            int countermax = 0;
            int position = 0;

            for (int i = 0; i < arry.Length-1; i++)
            {
                if (arry[i]<arry[i+1])
                {
                    counter++;
                    if (counter>countermax)
                    {
                        countermax = counter;
                        position = i + 1;
                    }
                }
                else
                {
                    counter = 1;

                }
            }

            int [] result = new int[countermax];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = arry[position - countermax + 1 + i];
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
