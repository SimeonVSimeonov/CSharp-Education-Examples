using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        internal Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Cargo = cargo;
            this.Tires = tires;

        }

        internal Engine Engine { get => engine; set => engine = value; }
        internal Cargo Cargo { get => cargo; set => cargo = value; }
        public string Model { get => model; set => model = value; }
        public List<Tire> Tires { get => tires; set => tires = value; }
    }
}
