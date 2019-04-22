using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;

        private List<IFood> foodsOrders;
        private List<IDrink> drinksOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodsOrders = new List<IFood>();
            this.drinksOrders = new List<IDrink>();
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get { return capacity; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.numberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.drinksOrders = new List<IDrink>();
            this.foodsOrders = new List<IFood>();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            // return this.Price;
            decimal totalBill = 0;
            totalBill += foodsOrders.Sum(x => x.Price);
            totalBill += drinksOrders.Sum(x => x.Price);

            return totalBill;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

        public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (foodsOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodsOrders.Count}");

                foreach (var food in this.foodsOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (drinksOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinksOrders.Count}");

                foreach (var drink in this.drinksOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinksOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodsOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
    }
}
