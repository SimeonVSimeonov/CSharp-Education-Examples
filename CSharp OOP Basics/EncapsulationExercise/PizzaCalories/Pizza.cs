using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private List<string> toppings;
        private Dough dough;
        //, List<string> toppings, string dough
        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<string>();
            this.Dough = dough;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    ThrowException($"Pizza {name} should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public List<string> Toppings
        {
            get { return toppings; }
            set
            {
                if (toppings.Count > 10)
                {
                    ThrowException("Number of toppings should be in range [0..10].");
                }
                toppings = value;
            }
        }

        public Dough Dough
        {
           
            set { this.dough = value; }
        }

        private void ThrowException(string v)
        {
            throw new ArgumentException(v);
        }
    }
}
