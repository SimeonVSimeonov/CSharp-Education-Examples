using System;

namespace _04._Generating_01_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            Gen01(0, vector);
        }

        private static void Gen01(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen01(index + 1, vector);
                }
            }
        }
    }
}
