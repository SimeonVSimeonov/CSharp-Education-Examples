using P10ExplicitInterfaces.Contracts;

namespace P10ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Age { get; private set; }

        public Citizen(string name, string country, string age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + Name;
        }

        string IPerson.GetName()
        {
            return Name;
        }
    }
}
