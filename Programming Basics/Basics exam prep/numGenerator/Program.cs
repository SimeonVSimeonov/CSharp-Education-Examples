using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int spec = int.Parse(Console.ReadLine());
            int contr = int.Parse(Console.ReadLine());
            bool isFound = false;

            for (int a1 = m; a1 >= 1; a1--)
            {
                if (true)
                {

                }
                for (int a2 = n; a2 >= 1; a2--)
                {
                    for (int a3 = l; a3 >= 1; a3--)
                    {
                        int number = a1*100 + a2*10 + a3;
                        if (number%3==0)
                        {
                            spec += 5;
                        }
                        else if (number%10==5)
                        {
                            spec -= 2;
                        }
                        else if (number%2==0)
                        {
                            spec *= 2;
                        }
                        if (spec>=contr)
                        {
                            Console.WriteLine("yes  is {0}",spec);
                            isFound = true;
                            break;
                            //return;
                        }
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no {0}", spec);
            }
        }
    }
}
