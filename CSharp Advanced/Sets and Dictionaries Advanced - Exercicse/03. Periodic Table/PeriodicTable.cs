using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var setOfElements = new SortedSet<string>();

            for (int i = 0; i < size; i++)
            {
                var elements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var el in elements)
                {
                    setOfElements.Add(el);
                }
            }

            foreach (var item in setOfElements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
