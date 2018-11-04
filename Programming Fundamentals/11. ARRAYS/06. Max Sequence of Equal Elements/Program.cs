using System;
using System.Linq;


namespace _06._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 1;
            int countermax = 0;
            int numberMax = 0;

            for (int i = 0; i < arry.Length-1; i++)
            {
                if (arry[i]==arry[i+1])
                {
                    counter++;
                }
                else
                {
                    if (counter>countermax)
                    {
                        countermax = counter;
                        numberMax = arry[i];
                    }
                    counter = 1;
                }

                if (i+1==arry.Length-1)
                {
                    if (counter > countermax)
                    {
                        countermax = counter;
                        numberMax = arry[i];
                    }
                    counter = 1;
                }
            }

            for (int i = 0; i < countermax; i++)
            {
                Console.Write(numberMax + " ");
            }

        }
    }
}
