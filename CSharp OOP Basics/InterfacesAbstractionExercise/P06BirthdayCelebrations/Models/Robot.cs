using P06BirthdayCelebrations.Contracts;

namespace P06BirthdayCelebrations.Models
{
    public class Robot : IIdentifable

    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get { return model; }
            private set { model = value; }
        }

        public string Id
        {
            get => id;
            private set => id = value;
        }
    }
}
