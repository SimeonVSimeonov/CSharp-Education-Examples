using System;
using System.Numerics;

namespace _01._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            var numBalls = int.Parse(Console.ReadLine());
            BigInteger maxResult = 0;
            string result = "";

            for (int i = 0; i < numBalls; i++)
            {
                var snowballSnow = int.Parse(Console.ReadLine());
                var snowballTime = int.Parse(Console.ReadLine());
                var snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue>maxResult)
                {
                    result = string.Format($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");
                    maxResult = snowballValue;
                }
            }
            Console.WriteLine(result);
        }
    }
}
