using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stupidPass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int a1 = 1; a1 < n; a1++)
            {
                for (int a2 = 1; a2 < n; a2++)
                {
                    for (int firstChar = 97; firstChar <= 96+l; firstChar++)
                    {
                        for (char secondChar = 'a'; secondChar < 'a'+l; secondChar++)
                        {
                            for (int lastNum = Math.Max(a1,a2)+1; lastNum <= n; lastNum++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ",a1,a2,(char)firstChar,secondChar,lastNum);
                            }
                        }
                    }
                }
            }


        }
    }
}
