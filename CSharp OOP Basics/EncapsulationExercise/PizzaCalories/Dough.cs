using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (value != "white" && value != "wholegrain")
                {
                    ThrowException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value != "crispy" &&
                    value != "chewy" &&
                    value != "homemade")
                {
                    ThrowException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    ThrowException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double TotalCalories()
        {
            var modifierFlour = 0.0;
            var modifierTech = 0.0;

            switch (this.flourType)
            {
                case "white":
                    modifierFlour = 1.5;
                    break;
                case "wholegrain":
                    modifierFlour = 1.0;
                    break;
            }

            switch (this.bakingTechnique)
            {
                case "crispy":
                    modifierTech = 0.9;
                    break;
                case "chewy":
                    modifierTech = 1.1;
                    break;
                case "homemade":
                    modifierTech = 1.0;
                    break;

            }

            return (2 * weight) * modifierFlour * modifierTech;

        }

        private void ThrowException(string errorName)
        {
            throw new ArgumentException(errorName);
        }

    }
}
