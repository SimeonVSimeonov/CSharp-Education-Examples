using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbrs = new List<int>()
            { 100,200,300};
            numbrs.Add(400);
            numbrs.Add(500);
            Console.WriteLine(string.Join(", ",numbrs));
            numbrs.Insert(3, 350);
            Console.WriteLine(string.Join(", ",numbrs));
            int[] numberArr = { 20, 30, 40, 50 };
            numbrs.AddRange(numberArr);
            numbrs.Sort();
            numbrs.Reverse();
            Console.WriteLine(string.Join(", ", numbrs));
        }
    }
}
