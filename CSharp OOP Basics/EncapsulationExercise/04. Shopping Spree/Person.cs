using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Shopping_Spree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<string> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.products = new List<string>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    ThrowException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    ThrowException("Money cannot be negative");
                }
                money = value;
            }
        }

        public object Afford(Product product)
        {
            if (product.Cost > this.money)
            {
                return $"{this.name} can't afford {product.Name}";
            }
            else
            {
                this.money -= product.Cost;
                AddProduct(product.Name);
                return $"{Name} bought {product.Name}";
            }
        }

        private void AddProduct(string name)
        {
            this.products.Add(name);
        }

        public List<string> Products
        {
            get { return products; }
            set { products = value; }
        }

        private void ThrowException(string errorName)
        {
            throw new ArgumentException(errorName);
        }

        public override string ToString()
        {
            //return base.ToString();

            if (products.Count > 0)
            {
                return $"{Name} - {string.Join(", ", products)}";
            }

            return $"{Name} - Nothing bought";

        }
    }
}
