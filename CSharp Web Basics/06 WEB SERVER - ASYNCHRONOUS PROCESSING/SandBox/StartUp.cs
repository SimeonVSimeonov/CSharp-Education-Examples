using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SandBox
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(0, 10000).ToList();
            for (int i = 0; i < 4; i++)
            {
                new Thread(() =>
                {
                    while (numbers.Count > 0)
                        numbers.RemoveAt(numbers.Count - 1);
                }).Start();
            }



            //===================================================
            //List<long> numbers = new List<long>();
            //Thread t = new Thread(() =>
            //  SumOddNumbers(numbers, 10, 10));
            //t.Start();

            //Console.WriteLine("What should I do?");
            //while (true)
            //{
            //    string command = Console.ReadLine();
            //    if (command == "exit") break;
            //}

            //t.Join();

            //================================================================
            //Thread thread = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //});
            //==============================================================
            //Thread primes = new Thread(() => PrintPrimesInRange(1, 10000));
            //primes.Start();

            //Console.WriteLine("Waiting for thread to finish work...");
            //primes.Join();
            //==================================================================
            //Console.Write("Enter your name: ");
            //string name = Console.ReadLine();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine($"Hello, {name}!");
            //=====================================================================

            //int n = int.Parse(Console.ReadLine());

            //PrintNumbersInRange(0, 100);
            //var task = Task.Run(() =>
            //    PrintNumbersInRange(100, 200));
            //var task2 = Task.Run(() =>
            //PrintNumbersInRange(200, 300));

            //Console.WriteLine("Done.");
            //task2.Wait();
            //Console.WriteLine("Done.");
            //task.Wait();
            //=====================================================================

        }

        private static void SumOddNumbers(List<long> numbers, int v1, long v2)
        {
            throw new NotImplementedException();
        }

        private static void PrintPrimesInRange(int v1, int v2)
        {
            for (int i = v1; i < v2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void PrintNumbersInRange(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
