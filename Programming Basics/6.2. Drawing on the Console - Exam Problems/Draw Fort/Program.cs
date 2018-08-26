using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_Fort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int colSize = n / 2;
            int midSize = 2 * n - 2 * colSize - 4;

            Console.WriteLine("/{0}\\{1}/{0}\\",new string('^',colSize),new string('_',midSize));
            int freeSpace = 2 * n - 2;
            for (int i = 1; i <=n-3 ; i++)
            {
                Console.WriteLine("|{0}|",new string(' ',freeSpace));
            }
            Console.WriteLine("|{0}{1}{0}|",new string(' ',colSize+1),new string('_',midSize));
            Console.WriteLine("\\{0}/{1}\\{0}/",new string('_',colSize),new string(' ',midSize));

        }
    }
}
