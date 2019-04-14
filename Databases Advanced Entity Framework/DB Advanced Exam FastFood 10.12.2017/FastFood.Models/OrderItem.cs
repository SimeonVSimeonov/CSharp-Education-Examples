using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Required]
        [Range(1, 2147483647)]
        public int Quantity { get; set; }

        //•	OrderId– integer, Primary Key
        //•	Order – the item’s order(required)
        //•	ItemId – integer, Primary Key
        //•	Item – the order’s item(required)
        //•	Quantity–the quantity of theitem in the order(required, non-negative and non-zero)
    }
}
