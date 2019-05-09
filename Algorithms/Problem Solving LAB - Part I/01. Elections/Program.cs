using System;
using System.Linq;
using System.Numerics;

namespace _01._Elections
{
    class Program
    {
        static void Main(string[] args)
        {
            var majoritySeats = int.Parse(Console.ReadLine());
            var parties = int.Parse(Console.ReadLine());

            int[] arrayPartiesSeats = new int[parties];

            for (int i = 0; i < parties; i++)
            {
                arrayPartiesSeats[i] = int.Parse(Console.ReadLine());
            }

            BigInteger[] sums = new BigInteger[arrayPartiesSeats.Sum() + 1];
            sums[0] = 1;

            foreach (var partiesSeats in arrayPartiesSeats)
            {
                for (int i = sums.Length - 1; i >= 0; i--)
                {
                    if (sums[i] != 0)
                    {
                        sums[i + partiesSeats] += sums[i];
                    }
                }
            }

            BigInteger count = 0;
            for (int i = majoritySeats; i < sums.Length; i++)
            {
                count += sums[i];
            }

            Console.WriteLine(count);
           
        }
    }
}
