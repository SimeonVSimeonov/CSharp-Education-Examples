using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ivanovi_s_Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            int overnightCount = int.Parse(Console.ReadLine());
            string destination = Console.ReadLine().ToLower();
            string transport = Console.ReadLine().ToLower();

            if (destination == "miami")
            {
                double pricePerentOver = 0;
                double priceKids = 0;
                double pricePerentTransport = 0;
                double priceKidsTransport = 0;
                if (overnightCount <= 10)
                {
                    pricePerentOver = overnightCount * 24.99 * 2;
                    priceKids = overnightCount * 14.99 * 3;
                }
                else if (overnightCount <= 15)
                {
                    pricePerentOver = overnightCount * 22.99 * 2;
                    priceKids = overnightCount * 11.99 * 3;
                }
                else
                {
                    pricePerentOver = overnightCount * 20.00 * 2;
                    priceKids = overnightCount * 10.00 * 3;
                }
                if (transport == "train")
                {
                    pricePerentTransport = 2 * 22.30;
                    priceKidsTransport = 3 * 12.50;
                }
                else if (transport == "bus")
                {
                    pricePerentTransport = 2 * 45.00;
                    priceKidsTransport = 3 * 37.00;
                }
                else if (transport == "airplane")
                {
                    pricePerentTransport = 2 * 90.00;
                    priceKidsTransport = 3 * 68.50;
                }
                Console.WriteLine("{0:f3}", (pricePerentTransport + priceKidsTransport + (pricePerentOver + priceKids) * 1.25));
            }
            if (destination == "canary islands")
            {
                double pricePerentOver = 0;
                double priceKids = 0;
                double pricePerentTransport = 0;
                double priceKidsTransport = 0;
                if (overnightCount <= 10)
                {
                    pricePerentOver = overnightCount * 32.50 * 2;
                    priceKids = overnightCount * 28.50 * 3;
                }
                else if (overnightCount <= 15)
                {
                    pricePerentOver = overnightCount * 30.50 * 2;
                    priceKids = overnightCount * 25.60 * 3;
                }
                else
                {
                    pricePerentOver = overnightCount * 28.00 * 2;
                    priceKids = overnightCount * 22.00 * 3;
                }
                if (transport == "train")
                {
                    pricePerentTransport = 2 * 22.30;
                    priceKidsTransport = 3 * 12.50;
                }
                else if (transport == "bus")
                {
                    pricePerentTransport = 2 * 45.00;
                    priceKidsTransport = 3 * 37.00;
                }
                else if (transport == "airplane")
                {
                    pricePerentTransport = 2 * 90.00;
                    priceKidsTransport = 3 * 68.50;
                }
                Console.WriteLine("{0:f3}", (pricePerentTransport + priceKidsTransport + (pricePerentOver + priceKids) * 1.25));
            }
            if (destination == "philippines")
            {
                double pricePerentOver = 0;
                double priceKids = 0;
                double pricePerentTransport = 0;
                double priceKidsTransport = 0;
                if (overnightCount <= 10)
                {
                    pricePerentOver = overnightCount * 42.99 * 2;
                    priceKids = overnightCount * 39.99 * 3;
                }
                else if (overnightCount <= 15)
                {
                    pricePerentOver = overnightCount * 41.00 * 2;
                    priceKids = overnightCount * 36.00 * 3;
                }
                else
                {
                    pricePerentOver = overnightCount * 38.50 * 2;
                    priceKids = overnightCount * 34.20 * 3;
                }
                if (transport == "train")
                {
                    pricePerentTransport = 2 * 22.30;
                    priceKidsTransport = 3 * 12.50;
                }
                else if (transport == "bus")
                {
                    pricePerentTransport = 2 * 45.00;
                    priceKidsTransport = 3 * 37.00;
                }
                else if (transport == "airplane")
                {
                    pricePerentTransport = 2 * 90.00;
                    priceKidsTransport = 3 * 68.50;
                }
                Console.WriteLine("{0:f3}", (pricePerentTransport + priceKidsTransport + (pricePerentOver + priceKids) * 1.25));
            }

        }
    }
}
