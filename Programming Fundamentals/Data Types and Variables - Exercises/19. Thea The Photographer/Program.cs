using System;

namespace _19._Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long picTaken = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int goodToUp = int.Parse(Console.ReadLine());
            long upTime = int.Parse(Console.ReadLine());

            var picForUp = (int)Math.Ceiling(picTaken * goodToUp / 100.0);
            var allFilterPic = picTaken * filterTime;
            var timePicForUp = picForUp * upTime;
            var totalTime = timePicForUp + allFilterPic;

            //var seconds = (int)(totalTime % 60);
            //totalTime = (totalTime - (totalTime % 60)) / 60;
            //var minutes = (int)(totalTime % 60);
            //totalTime = (totalTime - (totalTime % 60)) / 60;
            //var hours = (int)(totalTime % 24);
            //totalTime = (totalTime - (totalTime % 24)) / 24;

            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            var answer = string.Format("{0}:{1:D2}:{2:D2}:{3:D2}", time.Days, time.Hours, time.Minutes, time.Seconds);
            Console.WriteLine(answer);
            //Console.WriteLine($"{totalTime}:{hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
