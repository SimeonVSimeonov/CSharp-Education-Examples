using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pipe1 = int.Parse(Console.ReadLine());
            int pipe2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double totalPipe1 = pipe1 * hours;
            double totalPipe2 = pipe2 * hours;
            double water = totalPipe1 + totalPipe2;
            if (water<=volume)
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    Math.Truncate(water/volume*100),Math.Truncate(totalPipe1/water*100), 
                    Math.Truncate(totalPipe2/water*100));
            }
            else
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.",hours,water-volume);
            }
        }
    }
}
