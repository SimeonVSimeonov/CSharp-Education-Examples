using System;

namespace _14._Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = char.Parse(Console.ReadLine());
            var secondLine = char.Parse(Console.ReadLine());
            var toAvoid = char.Parse(Console.ReadLine());

            for (char i = firstLine; i <= secondLine; i++)
            {
                for (char j = firstLine; j <= secondLine; j++)
                {
                    for (char k = firstLine; k <= secondLine; k++)
                    {
                        if (i != toAvoid && j != toAvoid && k != toAvoid)
                        {
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }

        }
    }
}
