using System;
using System.Numerics;

namespace _01.Dynamic_Programming
{
    class Program
    {
        static int participants;
        static bool[,] symbols;
        static BigInteger[] cache;

        static void Main(string[] args)
        {
            participants = int.Parse(Console.ReadLine());
            symbols = new bool[participants, participants];
            cache = new BigInteger[participants];

            for (int i = 0; i < participants; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < participants; j++)
                {
                    symbols[i, j] = input[j] == 'R';
                }
            }
            
            BigInteger sumMoney = 0;
            for (int i = 0; i < participants; i++)
            {
                sumMoney += FindMoney(i);
            }

            Console.WriteLine($"${sumMoney}.00");
        }

        private static BigInteger FindMoney(int person)
        {
            if (cache[person] > 0)
            {
                return cache[person];
            }

            BigInteger money = 0;
            var refer = 0;
            for (int i = 0; i < participants; i++)
            {
                if (symbols[person, i])
                {
                    money += FindMoney(i);
                    refer++;
                }
            }

            money *= refer;

            if (money == 0)
            {
                money = 1;
            }

            cache[person] = money;
            return money;
        }
    }
}
