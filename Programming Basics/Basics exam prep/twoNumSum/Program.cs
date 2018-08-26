using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoNumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int br = 0;
            bool isFound = false;

            for (int a1 = start; a1 >= end; a1--)
            {
                if (isFound=true)
                {
                    break;
                }
                for (int a2 = 0; a2 >= end; a2--)
                {
                    br++;
                    if (a1+a2==magic)
                    {
                        isFound = true;
                        Console.WriteLine($"comb N: {br}{a1}{a2}");
                        break;

                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{br}not{magic}");
            }
        }
    }
}
