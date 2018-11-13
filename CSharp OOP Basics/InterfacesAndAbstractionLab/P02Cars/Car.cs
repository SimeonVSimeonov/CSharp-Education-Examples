using System.Text;

namespace Cars
{
    public class Car : ICar
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        protected virtual string GetCarInfo()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.GetCarInfo())
                .AppendLine(this.Start())
                .Append(this.Stop());

            return builder.ToString();

        }
    }
}

