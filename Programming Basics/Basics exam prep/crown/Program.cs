using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crown
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 2 * n - 1;
            int totalRows = n / 4 - 2;
            int countSpaces = (width - 3) / 2;
            Console.WriteLine("@{0}@{0}@",new string(' ',countSpaces));
            countSpaces--;
            Console.WriteLine("**{0}*{0}**", new string(' ', countSpaces));
            int countOutDots = 1,contInnerDots = 1;
            countSpaces-=2;


            for (int row = 0; row < totalRows-6; contInnerDots+=2,countOutDots++,countSpaces-=2)
            {
                Console.WriteLine("*{0}*{1}*{2}*{1}*{0}", new string('.', countOutDots), new string(' ',countSpaces),new string('.',countOutDots));
            }
            Console.WriteLine("*{0}*{1}*{0}", new string('.', countOutDots), new string('.', countOutDots));
            countOutDots++;
            int countStarCenter = ((width - 3) - 2 * countOutDots) / 2;
            Console.WriteLine("*{0}{1}.{1}{0}",new string('.',countOutDots),new string('*',countStarCenter));


        }
    }
}
