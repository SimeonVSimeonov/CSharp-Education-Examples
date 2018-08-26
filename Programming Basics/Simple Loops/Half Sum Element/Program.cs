using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var max = int.MinValue;
            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num>max)
                {
                    max = num;
                }
                sum = num + sum;
            }
            var otherSum = sum - max;
            if (otherSum==max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = "+max);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = "+Math.Abs(max-otherSum));
            }
        }
    }
}
