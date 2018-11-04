using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01._Anonymous_Downsite
{
    class Program
    {
        static void Main(string[] args)
        {
            var numAfected =int.Parse(Console.ReadLine());
            var securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            var allSiteName = new List<string>();

            for (int i = 0; i < numAfected; i++)
            {
                var afectedSite = Console.ReadLine();
                var siteData = afectedSite.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var siteName = siteData[0];
                var siteVisits = long.Parse(siteData[1]);
                var sitePricePerVisit = decimal.Parse(siteData[2]);
                
                totalLoss += siteVisits * sitePricePerVisit;
                allSiteName.Add(siteName);
            }

            foreach (var site in allSiteName)
            {
                Console.WriteLine(site);
            }
            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey,numAfected)}");
        }
    }
}
