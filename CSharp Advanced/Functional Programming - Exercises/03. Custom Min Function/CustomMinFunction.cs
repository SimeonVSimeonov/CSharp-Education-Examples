using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> findMin = x => x.Min();

            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(findMin(array));
        }
    }
}
