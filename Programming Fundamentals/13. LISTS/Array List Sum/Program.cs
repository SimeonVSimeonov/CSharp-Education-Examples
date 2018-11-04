using System;
using System.Collections;

namespace Array_List_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList numbers = new ArrayList();
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int value = (int)numbers[i];
                sum = sum + value;
            }
            Console.WriteLine(sum);
        }
    }
}
