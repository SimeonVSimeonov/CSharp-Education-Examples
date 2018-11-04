using P07FoodShortage.Contracts;

namespace P07FoodShortage.Models
{
    public class Citizen : Person, IIdentifable
    {
        private const int increasingNumber = 10;

        public string Id { get; }
        public string Birthdate { get; }

        public Citizen(string name, int age, string id, string birthdate)
            : base(name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public override void BuyFood()
        {
            Food += increasingNumber;
        }
    }
}
