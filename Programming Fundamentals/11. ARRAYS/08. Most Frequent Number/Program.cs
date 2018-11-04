using System;
using System.Linq;

namespace _08._Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] counters = new int[arry.Length];
            int counterMax = 0;
            int numberMax = 0;

            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = i; j < arry.Length; j++)
                {
                    if (arry[i]==arry[j])
                    {
                        counters[i]++;
                        if (counters[i]>counterMax)
                        {
                            counterMax = counters[i];
                            numberMax = arry[i];
                        }
                    }

                }
            }
            Console.WriteLine(numberMax);
        }
    }
}
