using System;
using System.Collections.Generic;

namespace GetPrimes
{
    class Program
    {
        public static List<int> GetPrimes(int start, int end)

        {
            List<int> primesList = new List<int>();

            for (int num = start; num <= end; num++)

            {
                bool prime = true;
                double numSqrt = Math.Sqrt(num);
      
                for (int div = 2; div <= numSqrt; div++)

                {

                    if (num % div == 0)

                    {
                        prime = false;
                        break;
                    }
                }

                if (prime)

                {
                    primesList.Add(num);
                }
            }
            return primesList;
        }

        public static void Main()

        {
            List<int> primes = GetPrimes(200, 300);

            foreach (var item in primes)

            {
                Console.WriteLine("{0} ", item);
            }

        }
    }
}
