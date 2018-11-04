namespace P08MilitaryElite.Contracts
{
    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        //TODO add validation

        public int Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string FirstName
        {
            get => firstName;
            private set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            private set => lastName = value;
        }

        public override string ToString()
        {
            return $"Name: {this.firstName} {this.lastName} Id: {this.id} ";
        }
    }
}
