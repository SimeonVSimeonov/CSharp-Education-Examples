using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            var lot = new HashSet<string>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var data = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var goTo = data[0];
                var carNumber = data[1];

                if (goTo == "IN")
                {
                    lot.Add(carNumber);
                }
                else
                {
                    lot.Remove(carNumber);
                }

            }
            if (lot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var car in lot)
            {
                Console.WriteLine(car);
            }
        }
    }
}
