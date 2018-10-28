using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Shopping_Spree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            GetPeople(people);
            GetProducts(products);

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "END")
                {
                    break;
                }

                var person = people.FirstOrDefault(p => p.Name == command[0]);
                var product = products.FirstOrDefault(p => p.Name == command[1]);

                if (person != null && product != null)
                {
                    var afford = person.Afford(product);
                    Console.WriteLine(afford);
                }
            }

            people.ForEach(p => Console.WriteLine(p));
        }

        private static void GetProducts(List<Product> products)
        {
            var inputProductCost = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputProductCost.Length; i += 2)
            {
                string name = inputProductCost[i];
                decimal cost = decimal.Parse(inputProductCost[i + 1]);

                try
                {
                    products.Add(new Product(name, cost));


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

            }
        }

        private static void GetPeople(List<Person> people)
        {
            var inputPeopleMoney = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputPeopleMoney.Length; i += 2)
            {
                string name = inputPeopleMoney[i];
                decimal money = decimal.Parse(inputPeopleMoney[i + 1]);

                try
                {
                    var person = new Person(name, money);
                    people.Add(person);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
