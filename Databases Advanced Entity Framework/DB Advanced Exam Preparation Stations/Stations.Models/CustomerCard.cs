using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Stations.Models.Enums;

namespace Stations.Models
{
    public class CustomerCard
    {
        public CustomerCard()
        {
            this.BoughtTickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public CardType Type { get; set; }

        public ICollection<Ticket> BoughtTickets { get; set; }

        //•	Id– integer, Primary Key
        //•	Name – text with max length128(required)
        //•	Age– integer between0 and 120
        //•	Type– CardType enumeration with values:"Pupil", "Student", "Elder","Debilitated", "Normal" (default: Normal)
        //•	BoughtTickets– Collection of type Ticket

    }
}
