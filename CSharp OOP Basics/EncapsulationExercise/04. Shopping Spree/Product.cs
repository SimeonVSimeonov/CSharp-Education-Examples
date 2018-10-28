using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Shopping_Spree
{
    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    ThrowException("Money cannot be negative");
                }
                cost = value;
            }
        }

        private void ThrowException(string errorName)
        {
            throw new ArgumentException(errorName);
        }
    }
}
