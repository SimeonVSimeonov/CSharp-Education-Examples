using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLoads = int.Parse(Console.ReadLine());

            double sumOfTons = 0.0;
            double microbusTons = 0.0;
            double microbusLoads = 0.0;
            double truckTons = 0.0;
            double truckLoads = 0.0;
            double trainTons = 0.0;
            double trainLoads = 0.0;
            double totalPrice = 0.0;

            for (int loads = 0; loads <= countOfLoads-1; loads++)
            {
                int loadsTons = int.Parse(Console.ReadLine());

                if (loadsTons<=3)
                {
                    microbusLoads++;
                    microbusTons += loadsTons;
                    sumOfTons += loadsTons;
                }
                else if (loadsTons<=11)
                {
                    truckLoads++;
                    truckTons += loadsTons;
                    sumOfTons += loadsTons;
                }
                else
                {
                    trainLoads++;
                    trainTons += loadsTons;
                    sumOfTons += loadsTons;
                }
                totalPrice = microbusTons * 200 + truckTons * 175 + trainTons * 120;
            }
            Console.WriteLine("{0:f2}",totalPrice/sumOfTons);
            Console.WriteLine("{0:f2}%",microbusTons/sumOfTons*100);
            Console.WriteLine("{0:f2}%",truckTons/sumOfTons*100);
            Console.WriteLine("{0:f2}%",trainTons/sumOfTons*100);
        }
    }
}

