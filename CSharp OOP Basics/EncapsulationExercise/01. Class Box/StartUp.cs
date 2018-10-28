using System;

namespace _01._Class_Box
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.Area(length, width, height):F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(length, width, height):F2}");
            Console.WriteLine($"Volume - {box.Volume(length, width, height):F2}");
        }
    }
}
