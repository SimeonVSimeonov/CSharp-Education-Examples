using System;

namespace P01Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var visitedHomes = int.Parse(Console.ReadLine());
            var initialPresents = int.Parse(Console.ReadLine());

            int presentsNumber = initialPresents;
            int timesBack = 0;
            int additionalPresentsTaken = 0;

            for (int currentHome = 1; currentHome <= visitedHomes; currentHome++)
            {
                var childs = int.Parse(Console.ReadLine());

                if (presentsNumber >= childs)
                {
                    presentsNumber -= childs;
                }
                else
                {
                    timesBack++;
                    int presentsNeeded =
                        (initialPresents / currentHome) * (visitedHomes - currentHome) + (childs - presentsNumber);

                    additionalPresentsTaken += presentsNeeded;
                    presentsNumber += presentsNeeded;
                    presentsNumber -= childs;
                }

            }

            if (timesBack == 0)
            {
                Console.WriteLine(presentsNumber);
            }
            else
            {
                Console.WriteLine(timesBack);
                Console.WriteLine(additionalPresentsTaken);
            }
        }
    }
}
