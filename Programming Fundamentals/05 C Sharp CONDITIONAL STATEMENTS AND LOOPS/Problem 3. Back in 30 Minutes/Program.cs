using System;

namespace Problem_3._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes>59)
            {
                minutes -= 60;
                hours++;
            }
            if (hours>23)
            {
                hours -= 24;
            }
            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
