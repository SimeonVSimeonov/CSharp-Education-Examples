using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            string input;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] productsData = input.Split(", ");
                string shop = productsData[0];
                string product = productsData[1];
                var price = double.Parse(productsData[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }

            foreach (var kvp in shops)
            {
                Console.WriteLine(kvp.Key + "->");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
