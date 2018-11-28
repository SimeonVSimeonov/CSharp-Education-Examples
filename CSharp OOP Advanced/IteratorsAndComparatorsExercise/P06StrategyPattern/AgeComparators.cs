namespace P06StrategyPattern
{
    using System.Collections.Generic;

    public class AgeComparators : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
