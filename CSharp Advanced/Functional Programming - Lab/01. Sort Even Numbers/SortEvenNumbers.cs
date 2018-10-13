using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(y => y)));
        }
    }
}
