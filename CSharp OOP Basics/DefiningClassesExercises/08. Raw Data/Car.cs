﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Raw_Data
{
    public class Car
    {
        //model, engine, cargo and a collection of exactly 4 tires.

        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }
    }
}
