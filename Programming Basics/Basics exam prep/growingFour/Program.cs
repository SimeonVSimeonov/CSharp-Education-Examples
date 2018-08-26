using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace growingFour
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            if (end-start<3)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int n1 = start; n1 <= end - 3; n1++)
                {
                    for (int n2 = n1 + 1; n2 <= end - 2; n2++)
                    {
                        for (int n3 = n2 + 1; n3 <= end - 1; n3++)
                        {
                            for (int n4 = 0; n4 < end; n4++)
                            {
                                Console.WriteLine($"{n1} {n2} {n3} {n4}");
                            }
                        }
                    }
                }
            }
        }
    }
}
