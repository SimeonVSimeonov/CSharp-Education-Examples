using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divNumber = int.Parse(Console.ReadLine());

            Action<List<int>> print = p => Console.WriteLine(string.Join(" ", p));
            Action<List<int>> revers = nums => nums.Reverse();
            Func<List<int>, List<int>> removeNumbers = numbres => numbres.Where(x => x % divNumber != 0).ToList();

            revers(inputNumbers);
            inputNumbers = removeNumbers(inputNumbers);
            print(inputNumbers);
        }
    }
}
