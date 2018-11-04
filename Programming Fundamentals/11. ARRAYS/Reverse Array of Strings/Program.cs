using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(' ').ToArray();
            for (int i = 0; i < elements.Length/2; i++)
            {
                SwapElements(elements, i, elements.Length - 1 - i);                
            }
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void SwapElements(string[] arry, int i, int v)
        {
            var oldElement = arry[i];
            arry[i] = arry[v];
            arry[v] = oldElement;           
        }
    }
}
