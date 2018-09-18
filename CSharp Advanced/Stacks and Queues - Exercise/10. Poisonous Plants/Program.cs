using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantCount = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var daysToDie = new int[plantCount];
            var plantsLeft = new Stack<int>();
            plantsLeft.Push(0);

            for (int i = 1; i < plantCount; i++)
            {
                int maxDaysDie = 0;
                while (plantsLeft.Count != 0 && plants[plantsLeft.Peek()] >= plants[i])
                {
                    maxDaysDie = Math.Max(maxDaysDie, daysToDie[plantsLeft.Pop()]);
                }

                if (plantsLeft.Count != 0)
                {
                    daysToDie[i] = maxDaysDie + 1;
                }
                plantsLeft.Push(i);
            }
            Console.WriteLine(daysToDie.Max());
        }
    }
}
