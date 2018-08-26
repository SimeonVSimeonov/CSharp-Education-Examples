using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var num = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                var min = int.Parse(Console.ReadLine());
                if (min<num)
                {
                    num=min;
                }
            }
            Console.WriteLine(num);
        }
    }
}
