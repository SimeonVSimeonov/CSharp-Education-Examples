using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futbolLeage
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int totalFans = int.Parse(Console.ReadLine());
            int sectorA = 0;
            int sectorB = 0;
            int sectorC = 0;
            int sectorD = 0;


            for (int fenNumber = 1; fenNumber <= totalFans; fenNumber++)
            {
                string sectorName = Console.ReadLine();
                switch (sectorName)
                {
                    case "A":
                        sectorA++;
                        break;
                    case "B":
                        sectorB++;
                        break;
                    case "C":
                        sectorC++;
                        break;
                    case "D":
                        sectorD++;
                        break;

                }
            }
            Console.WriteLine("{0:f2}%",sectorA*100.0 /totalFans);
            Console.WriteLine("{0:f2}%", sectorB*100.0 / totalFans);
            Console.WriteLine("{0:f2}%", sectorC*1.0 / totalFans * 100.0);
            Console.WriteLine("{0:f2}%", sectorD*1.0 / totalFans * 100.0);
            Console.WriteLine("{0:f2}%",totalFans*1.0 / capacity*100);
        }
    }
}
