using System;

namespace _01._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokePower = int.Parse(Console.ReadLine());
            var distance = int.Parse(Console.ReadLine());
            var exhaustionFactror = int.Parse(Console.ReadLine());
            var countPoke = 0;
            var currentPower = pokePower;


            while (currentPower>=distance)
            {
                countPoke++;
                currentPower -= distance;

                if (currentPower==pokePower/2 && pokePower%2==0 && exhaustionFactror!=0)
                {
                    currentPower /= exhaustionFactror;
                }

            }

            Console.WriteLine(currentPower);
            Console.WriteLine(countPoke);
        }
    }
}
