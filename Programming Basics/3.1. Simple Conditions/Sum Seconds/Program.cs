using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstComp = int.Parse(Console.ReadLine());
            int secondComp = int.Parse(Console.ReadLine());
            int thirdComp = int.Parse(Console.ReadLine());

            int seconds = firstComp + secondComp + thirdComp;
            int minutes = 0;

            if (seconds<=59)
            {
                 
            }
            else if (seconds<=119)
            {
                minutes++;
                seconds = seconds - 60;
            }
            else if (seconds<=179)
            {
                minutes+=2;
                seconds = seconds - 120;
            }
            if (seconds<10)
            {
                Console.WriteLine(minutes + ":" + "0" + seconds);
            }
            else
            {
                Console.WriteLine(minutes+":"+seconds);
            }
        }
    }
}
