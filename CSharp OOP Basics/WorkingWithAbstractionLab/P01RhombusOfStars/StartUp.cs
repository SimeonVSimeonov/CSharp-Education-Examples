using System;

namespace P01RhombusOfStars
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int starCount = 1; starCount <= size; starCount++)
            {
                PrintRow(size, starCount);
            }

            for (int starCount = size - 1; starCount >= 1; starCount--)
            {
                PrintRow(size, starCount);
            }
        }

        private static void PrintRow(int size, int starCount)
        {
            for (int i = 0; i < size-starCount; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < starCount; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
