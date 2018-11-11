using P03WildFarm.Foods.Contracts;

namespace P03WildFarm.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            //TODO
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
