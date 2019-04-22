using SoftUniRestaurant.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurantController;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.restaurantController = new RestaurantController();
        }

        public void Run()
        {
            string command = String.Empty;

            while ((command = this.reader.ReadData()) != "END")
            {
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            this.writer.WriteLine(this.restaurantController.GetSummary());
        }

        private void ReadCommand(string command)
        {
            string[] tokens = command.Split(" ");
            var output = string.Empty;
            string[] data = tokens.Skip(1).ToArray();

            switch (tokens[0])
            {
                case "AddFood":
                    {
                        var type = data[0];
                        var name = data[1];
                        var price = decimal.Parse(data[2]);

                        output = this.restaurantController.AddFood(type, name, price);
                        break;
                    }

                case "AddDrink":
                    {
                        string type = data[0];
                        string name = data[1];
                        int servingSize = int.Parse(data[2]);
                        string brand = data[3];
                        output = this.restaurantController.AddDrink(type, name, servingSize, brand);
                        break;
                    }
               
                case "AddTable":
                    {
                        string type = data[0];
                        int tableNumber = int.Parse(data[1]);
                        int capacity = int.Parse(data[2]);
                        output = this.restaurantController.AddTable(type, tableNumber, capacity);
                        break;
                    }
                
                case "ReserveTable":
                    {
                        int numberOfPeople = int.Parse(data[0]);
                        output = this.restaurantController.ReserveTable(numberOfPeople);
                        break;
                    }
               
                case "OrderFood":
                    {
                        int tableNumber = int.Parse(data[0]);
                        string foodName = data[1];
                        output = this.restaurantController.OrderFood(tableNumber, foodName);
                        break;
                    }
               
                case "OrderDrink":
                    {
                        int tableNumber = int.Parse(data[0]);
                        string drinkName = data[1];
                        string drinkBrand = data[2];
                        output = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                        break;
                    }
               
                case "LeaveTable":
                    {
                        int tableNumber = int.Parse(data[0]);
                        output = this.restaurantController.LeaveTable(tableNumber);
                        break;
                    }
                
                case "GetFreeTablesInfo":
                    {
                        output = this.restaurantController.GetFreeTablesInfo();
                        break;
                    }
               
                case "GetOccupiedTablesInfo":
                    {
                        output = this.restaurantController.GetOccupiedTablesInfo();
                        break;
                    }
            }
            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
