﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Raw_Data
{
    public class Tire
    {
        //<Tire1Pressure><Tire1Age>

        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}
