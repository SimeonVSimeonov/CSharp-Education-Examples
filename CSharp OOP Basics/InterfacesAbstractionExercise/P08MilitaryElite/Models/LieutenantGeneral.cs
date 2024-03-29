﻿using System.Collections.Generic;

namespace P08MilitaryElite.Contracts
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }
        //TODO add readonly collection
        public ICollection<IPrivate> Privates
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPrivates:{ (this.Privates.Count == 0 ? "" : "\n")}" +
                   $"{ string.Join("\n  ", this.Privates)}";
        }
    }
}
