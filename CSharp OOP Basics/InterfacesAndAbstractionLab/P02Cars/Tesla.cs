using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, ICar, IElectricCar
    {
        public Tesla(string model, string color, int batteries) : base(model,color)
        {
            this.Batteries = batteries;
            //this.Model = model;
            //this.Color = color;
        }

        public int Batteries { get; private set; }

        //public string Model { get; private set; }

        //public string Color { get; private set; }

        //public string Start()
        //{
        //   return "engine start!";
        //}

        //public string Stop()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
