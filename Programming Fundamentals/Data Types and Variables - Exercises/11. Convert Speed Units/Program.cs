using System;

namespace _11._Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            var meters = int.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var seconds = int.Parse(Console.ReadLine());

            var time = seconds + minutes * 60 + hours * 3600;
            float mPerS = (float)meters / time;
            float kmPerH = ((float)meters / 1000) / ((float)time / 3600);
            float mpPerH = ((float)meters / 1609) / ((float)time / 3600);
            Console.WriteLine($"{mPerS}");
            Console.WriteLine($"{kmPerH}");
            Console.WriteLine($"{mpPerH}");


        }
    }
}
