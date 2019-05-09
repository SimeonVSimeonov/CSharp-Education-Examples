using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Parking_Zones
{
    public class Program
    {
        static void Main()
        {
            int zonesCount = int.Parse(Console.ReadLine());
            List<Zone> zones = new List<Zone>();

            for (int i = 0; i < zonesCount; i++)
            {
                string[] args = Console.ReadLine().Split(':');

                string zoneName = args[0];
                string[] param = args[1].Split(',');

                int x = int.Parse(param[0]);
                int y = int.Parse(param[1]);
                int width = int.Parse(param[2]);
                int height = int.Parse(param[3]);
                decimal price = decimal.Parse(param[4]);
                zones.Add(new Zone(zoneName, x, y, width, height, price));

            }

            string[] freeSpots = Console.ReadLine().Split(';');

            string[] targetSpot = Console.ReadLine().Split(',');
            int targetX = int.Parse(targetSpot[0]);
            int targetY = int.Parse(targetSpot[1]);

            int timeOfSingleBlock = int.Parse(Console.ReadLine());

            for (int i = 0; i < freeSpots.Length; i++)
            {
                string[] currentFreeSpot = freeSpots[i].Split(',');
                int currentX = int.Parse(currentFreeSpot[0]);
                int currentY = int.Parse(currentFreeSpot[1]);

                ParkingSpot parkSpot = new ParkingSpot(currentX, currentY, targetX, targetY);

                for (int j = 0; j < zones.Count; j++)
                {
                    if (currentX >= zones[j].MinX && currentX <zones[j].MaxX &&
                        currentY >= zones[j].MinY && currentY < zones[j].MaxY)
                    {
                        zones[j].AddParkingSpot(parkSpot);
                        break;
                    }
                }
            }

            ParkingSpot bestParkingSpace = null;
            decimal totalPrice = Decimal.MaxValue;
            int totalTime = int.MaxValue;
            string nameOfZone = string.Empty;

            for (int i = 0; i < zones.Count; i++)
            {
                ParkingSpot currentBest = zones[i].BestSpot;
                if (currentBest != null)
                {
                    int currentTime = currentBest.DistanceFromTarget * 2 * timeOfSingleBlock;
                    int timeInMins = currentTime % 60 == 0 ? currentTime / 60 : currentTime / 60 + 1;
                    decimal currentPrice = timeInMins * (decimal)zones[i].PricePerMin;
                    if (currentPrice < totalPrice || (currentPrice == totalPrice && currentTime < totalTime))
                    {
                        totalTime = currentTime;
                        totalPrice = currentPrice;
                        bestParkingSpace = currentBest;
                        nameOfZone = zones[i].ZoneName;
                    }
                }
            }

            Console.WriteLine("Zone Type: {0}; X: {1}; Y: {2}; Price: {3:F2}", nameOfZone, bestParkingSpace.CurrentX, bestParkingSpace.CurrentY, totalPrice);
        }
    }

    public class Zone
    {
        public Zone(string zoneName, int x, int y, int width, int height, decimal price)
        {
            this.ZoneName = zoneName;
            this.MinX = x;
            this.MinY = y;
            this.MaxX = x + width;
            this.MaxY = y + height;
            this.PricePerMin = price;
        }

        public string ZoneName { get; set; }

        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public decimal PricePerMin { get; set; }

        public ParkingSpot BestSpot { get; set; }

        public void AddParkingSpot(ParkingSpot parkSpot)
        {
            if (this.BestSpot == null || parkSpot.DistanceFromTarget < this.BestSpot.DistanceFromTarget)
            {
                this.BestSpot = parkSpot;
            }
        }
    }

    public class ParkingSpot : IComparable<ParkingSpot>
    {
        public ParkingSpot(int currentX, int currentY, int targetX, int targetY)
        {
            this.CurrentX = currentX;
            this.CurrentY = currentY;
            this.DistanceFromTarget = CalculateDistanceFromTarget(currentX, currentY, targetX, targetY);
        }

        public int CurrentX { get; set; }

        public int CurrentY { get; set; }

        public int DistanceFromTarget { get; set; }

        private int CalculateDistanceFromTarget(int currentX, int currentY, int targetX, int targetY)
        {
            int distance = (Math.Max(currentX, targetX) - Math.Min(currentX, targetX) +
                Math.Max(currentY, targetY) - Math.Min(currentY, targetY)) - 1;
            return distance;
        }

        public int CompareTo(ParkingSpot other)
        {
            return this.DistanceFromTarget.CompareTo(other.DistanceFromTarget);
        }
    }
}
