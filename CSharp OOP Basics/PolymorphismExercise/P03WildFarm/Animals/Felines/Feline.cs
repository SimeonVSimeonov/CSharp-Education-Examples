using P03WildFarm.Animals.Mammals;

namespace P03WildFarm.Animals.Felines
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            //TODO
            get { return breed; }
            set { breed = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
