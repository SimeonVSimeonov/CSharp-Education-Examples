using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int needHours = int.Parse(Console.ReadLine());
            int daysHas = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double workTime = daysHas * 0.9;
            double extraWork = workTime * 10;
            double totalWork = extraWork * workers;

            if (needHours<=totalWork)
            {
                Console.WriteLine("Yes!{0} hours left.",Math.Floor(totalWork-needHours));
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.",Math.Floor(needHours-totalWork));
            }
        }
    }
}
