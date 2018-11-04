using System;

namespace Reversed_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int lenght = array.Length;
            int[] reversed = new int[lenght];

            for (int index = 0; index < lenght; index++)
            {
                reversed[lenght - index - 1] = array[index];


            }
            for (int i = 0; i < lenght; i++)
            {
                Console.WriteLine(reversed[i] + " ");
            }
        }
    }
}
