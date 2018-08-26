using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int nTrainingDays = int.Parse(Console.ReadLine());
            double mKilometersFirstDay = double.Parse(Console.ReadLine());

            double kilometers = mKilometersFirstDay;
            double allKilometers  = 0 + mKilometersFirstDay;
            for (int days = 0; days < nTrainingDays; days++)
            {
                int increasesNorm = int.Parse(Console.ReadLine());
                kilometers += kilometers * increasesNorm/100;
                allKilometers += kilometers;
            }
            if (allKilometers>=1000)
            {
                Console.WriteLine("You've done a great job running {0} more kilometers!",Math.Ceiling(allKilometers-1000));
            }
            else
            {
                Console.WriteLine("Sorry Mrs. Ivanova, you need to run {0} more kilometers",Math.Ceiling(1000-allKilometers));
            }
        }
    }
}
