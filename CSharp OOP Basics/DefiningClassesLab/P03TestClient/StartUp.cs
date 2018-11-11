using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var accounts = new Dictionary<int, BankAccount>();
            string commands;

            while ((commands = Console.ReadLine()) != "End")
            {
                var commandArgs = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var type = commandArgs[0];
                var id = int.Parse(commandArgs[1]);

                switch (type)
                {
                    case "Create":
                        CreateAccount(accounts, id);
                        break;

                    case "Deposit":
                        if (isValidAccount(accounts, id))
                        {
                            accounts[id].Deposit(decimal.Parse(commandArgs[2]));
                        }
                        break;

                    case "Withdraw":
                        if (isValidAccount(accounts, id))
                        {
                            accounts[id].Withdraw(decimal.Parse(commandArgs[2]));
                        }
                        break;

                    case "Print":
                        if (isValidAccount(accounts, id))
                        {
                            Print(accounts, id);
                        }
                        break;
                }
            }
        }

        private static bool isValidAccount(Dictionary<int, BankAccount> accounts, int id)
        {
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return false;
            }
            return true;
        }

        private static void Print(Dictionary<int, BankAccount> accounts, int id)
        {
            Console.WriteLine(accounts[id]);
        }

        private static void CreateAccount(Dictionary<int, BankAccount> accounts, int id)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var current = new BankAccount();
                current.Id = id;
                accounts.Add(id, current);
            }
        }
    }
}
