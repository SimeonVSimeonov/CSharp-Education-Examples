using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FastFood.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        //TODO calc
        [Required]
        [NotMapped]
        public decimal TotalPrice { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        //•	Id – integer, Primary Key
        //•	Customer – text(required)
        //•	DateTime – date and time of the order(required)
        //•	Type – OrderType enumeration with possible values: “ForHere, ToGo(default: ForHere)” (required)
        //•	TotalPrice– decimal value(calculated property, (not mapped to database), required)
        //•	EmployeeId– integer, foreign key
        //•	Employee – The employee who will process the order(required)
        //•	OrderItems – collection of type OrderItem

    }
}
