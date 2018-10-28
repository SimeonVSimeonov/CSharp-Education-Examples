using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string topTypeName;
        private double topWeight;

        public Topping(string topTypeName, double topWeight)
        {
            this.TopTypeName = topTypeName;
            this.TopWeight = topWeight;
        }

        public string TopTypeName
        {
            get { return topTypeName; }
            set
            {
                if (value != "meat" &&
                    value != "veggies" &&
                    value != "cheese " &&
                    value != "sauce")
                {
                    ThrowException($"Cannot place {value} on top of your pizza.");
                }

                topTypeName = value;
            }
        }

        public double TopWeight
        {
            get { return topWeight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    ThrowException($"{topTypeName} weight should be in the range [1..50].");
                }

                topWeight = value;
            }
        }

        public double ToppingCalories()
        {
            var modifiersTopping = 0.0;
            switch (this.topTypeName)
            {
                case "meat":
                    modifiersTopping = 1.2;
                    break;
                case "veggies":
                    modifiersTopping = 0.8;
                    break;
                case "cheese":
                    modifiersTopping = 1.1;
                    break;
                case "sauce":
                    modifiersTopping = 0.9;
                    break;
            }

            return 2 * modifiersTopping * topWeight; ;
        }


        private void ThrowException(string errorName)
        {
            throw new ArgumentException(errorName);
        }
    }
}
