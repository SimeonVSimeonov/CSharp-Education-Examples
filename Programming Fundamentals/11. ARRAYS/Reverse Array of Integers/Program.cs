using System;
using System.Linq;

namespace Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int item = int.Parse(Console.ReadLine());
            var arry = new int[item];
            for (int i = 0; i < item; i++)
            {
                arry[i] = int.Parse(Console.ReadLine());
            }
            for (int i = item - 1; i >= 0; i--)
            {
                Console.Write(arry[i] + " ");
                Console.WriteLine();
            }
        }
    }
}
