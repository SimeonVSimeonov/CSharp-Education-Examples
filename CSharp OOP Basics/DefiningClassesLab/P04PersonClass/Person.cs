using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
    public class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person()
        {
            this.accounts = new List<BankAccount>();
        }

        public Person(string name, int age)
            : this()
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name, int age, List<BankAccount> accounts)
            : this(name, age)
        {
            this.accounts.AddRange(accounts);
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public List<BankAccount> Accounts { get => accounts; set => accounts = value; }

        public decimal GetBalance()
        {
            return this.accounts.Sum(acc => acc.Balance);
        }
    }
}
