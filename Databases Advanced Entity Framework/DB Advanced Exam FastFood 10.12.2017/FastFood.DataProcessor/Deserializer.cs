using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var importEmployees = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            var employees = new List<Employee>();

            var positions = new List<Position>();

            var sb = new StringBuilder();

            foreach (var employeeDto in importEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                };

                var position = context.Positions.FirstOrDefault(x => x.Name == employeeDto.Position);

                if (position == null)
                {
                    position = new Position { Name = employeeDto.Position };
                    context.Positions.Add(position);
                    context.SaveChanges();
                    employee.Position = position;
                }

                employee.Position = position;

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var itemsDto = JsonConvert.DeserializeObject<ImportItemsDto[]>(jsonString);

            var items = new List<Item>();

            var sb = new StringBuilder();

            foreach (var itemDto in itemsDto)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (items.Any(x => x.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price
                };

                var category = context.Categories.FirstOrDefault(x => x.Name == itemDto.Category);

                if (category == null)
                {
                    category = new Category { Name = itemDto.Category };
                    context.Categories.Add(category);
                    context.SaveChanges();
                    item.Category = category;
                }
                item.Category = category;
                items.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }
            
            context.Items.AddRange(items);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOrdersDto[]), new
             XmlRootAttribute("Orders"));

            var importOrdersDto = (ImportOrdersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var orders = new List<Order>();

            var sb = new StringBuilder();

            foreach (var orderDto in importOrdersDto)
            {
                var ordersItems = new List<OrderItem>();
                
                var employee = context.Employees.FirstOrDefault(x => x.Name == orderDto.Employee);

                if (!IsValid(orderDto) || employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var ctxItems = context.Items.Select(x => x.Name).ToArray();

                foreach (var itemDto in orderDto.Item)
                {

                    if (!ctxItems.Contains(itemDto.Name))
                    {
                        
                        sb.AppendLine(FailureMessage);
                        break;
                    }

                    var item = context.Items.FirstOrDefault(x => x.Name == itemDto.Name);
                    
                    var orderItem = new OrderItem
                    {
                        Item = item,
                        Quantity = itemDto.Quantity
                    };

                    ordersItems.Add(orderItem);
                }

                var date = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var order = new Order
                {
                    Customer = orderDto.Customer,
                    Employee = employee,
                    DateTime = date,
                    Type = Enum.Parse<OrderType>(orderDto.Type),
                    OrderItems = ordersItems

                };

                orders.Add(order);
                sb.AppendLine($"Order for {orderDto.Customer} on {date.ToString("dd/MM/yyyy HH:mm")} added");
            }
            
            context.Orders.AddRange(orders);
            context.SaveChanges();
            
            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}