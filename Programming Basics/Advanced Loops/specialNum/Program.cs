using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());



            for (int a1 = 0; a1 < 10; a1++)
                for (int a2 = 0; a2 < 10; a2++)
                    for (int a3 = 0; a3 < 10; a3++)
                        for (int a4 = 0; a4 < 10; a4++)
                        {
                            if (n % a1 == 0 && n% a2 == 0 && n % a3 == 0 && n % a4 == 0)
                            {
                                Console.Write($"{a1}{a2}{a3}{a4} ");
                            }
                        }
        }
    }
}
