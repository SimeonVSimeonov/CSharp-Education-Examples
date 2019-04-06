using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(8)]//TODO check for regex ???
        public string SeatingPlace { get; set; }

        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; }// TODO check Required ??

        public int? CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }

        //•	Id– integer, Primary Key
        //•	Price – decimal value of the ticket(required, non-negative)
        //•	SeatingPlace–text with max length of 8 which combines seating class abbreviation plus a positive integer(required)
        //•	TripId  – integer(required)
        //•	Trip – the trip for which the ticket is for(required)
        //•	CustomerCardId–integer(optional)
        //•	CustomerCard–reference to the ticket’sbuyer

    }
}
