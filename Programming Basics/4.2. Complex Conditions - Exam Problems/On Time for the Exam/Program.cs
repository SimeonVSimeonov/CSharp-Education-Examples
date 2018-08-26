using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArive= int.Parse(Console.ReadLine());
            int minuteArive = int.Parse(Console.ReadLine());

            string late = "Late ";
            string onTime = "On time";
            string early = "Early";

            int timeExam = (hourExam * 60) + minuteExam;
            int timeArive = (hourArive * 60) + minuteArive;
            int totalDiff = timeArive - timeExam;

            string studentArival = late;
            if (totalDiff<-30)
            {
                studentArival = early;
            }
            else if (totalDiff<=30&&totalDiff>=0)
            {
                studentArival = onTime;
            }
            else
            {
                studentArival = late;
            }
            string result = string.Empty;
            if (totalDiff!=0)
            {
                int hoursDiff = Math.Abs(totalDiff / 60);
                int minDiff = Math.Abs(totalDiff % 60);

                if (hoursDiff>0)
                {
                    result = string.Format("{0}:{1:00} hours", hoursDiff, minDiff);
                }
                else
                {
                    result = minDiff + " minutes";
                }
                if (totalDiff<0)
                {
                    result += " before the start";
                }
                else
                {
                    result += " after the start";
                }
            }
            Console.WriteLine(studentArival);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }


        }
    }
}
