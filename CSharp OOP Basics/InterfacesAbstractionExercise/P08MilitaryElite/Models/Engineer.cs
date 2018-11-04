﻿using P08MilitaryElite.Enums;
using System.Collections.Generic;

namespace P08MilitaryElite.Contracts
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corps}\nRepairs:" +
                   $"{ (this.Repairs.Count == 0 ? "" : "\n")}{ string.Join("\n", this.Repairs)}";
        }
    }
}
