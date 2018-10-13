using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> filter = x => x.Length <= length;

            Console.ReadLine()
                .Split()
                .Where(s => filter(s))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
