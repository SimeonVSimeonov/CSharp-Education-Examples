﻿namespace P06StrategyPattern
{
    using System.Collections.Generic;
    using System.Linq;

    public class NameComparators : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length.CompareTo(y.Name.Length) != 0)
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }

            return string.Compare(x.Name.First().ToString(), y.Name.First().ToString());
        }
    }
}
