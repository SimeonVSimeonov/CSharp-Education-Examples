namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Factories;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        private decimal totalIncomes = 0;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();

            this.totalIncomes = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = this.foodFactory.CreateFood(type, name, price);
            this.menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var table = this.tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(x => (x.IsReserved == false && x.Capacity >= numberOfPeople));

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = this.menu.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drink = this.drinks.FirstOrDefault(x => (x.Name == drinkName && x.Brand == drinkBrand));

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            
            //TODO throw error 
            if (table == null)
            {
                return "";
            }

            var totalBill = table.GetBill() + table.Price;

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {totalBill:f2}");

            this.totalIncomes += totalBill;
            table.Clear();
            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables.Where(x => x.IsReserved == false).ToList();
            var sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = this.tables.Where(x => x.IsReserved == true).ToList();
            var sb = new StringBuilder();

            foreach (var table in occupiedTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncomes:f2}lv";
        }
    }
}
