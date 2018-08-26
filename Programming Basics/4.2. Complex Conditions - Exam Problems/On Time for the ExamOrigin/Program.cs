using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Time_for_the_ExamOrigin
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int studentHour = int.Parse(Console.ReadLine());
            int studentMin = int.Parse(Console.ReadLine());

            examMin += examHour * 60;
            studentMin += studentHour * 60;
            int difference = examMin - studentMin;
            //if diff is negative student is late
            if (difference<0)
            {
                Console.WriteLine("Late");
                if (Math.Abs(difference)<60)
                {
                    Console.WriteLine("{0} minutes after the start", Math.Abs(difference));
                }
                else
                {
                    Console.WriteLine("{0}:{1:00} hours after the start", Math.Abs(difference/60),
                        Math.Abs(difference%60));
                }

            }
            else if (difference>0)
            {
                //stud is ok
                if (difference<=30)
                {
                    Console.WriteLine("On time");

                }
                else
                {
                    Console.WriteLine("Early");
                }
                if (difference<60)
                {
                    Console.WriteLine("{0} minutes before the start",difference);
                }
                else
                {
                    Console.WriteLine("{0}:{1:00} hours before the start",difference/60, difference%60);
                }

            }
            else
            {
                Console.WriteLine("On time");
            }
        }
    }
}
