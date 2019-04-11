using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerTicketsDto
    {
        [XmlElement("FirstName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(12, 110)]
        public int Age { get; set; }

        [XmlElement("Balance")]
        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketDto[] Tickets { get; set; }

        //     <Customer>
        // <FirstName>Randi</FirstName>
        // <LastName>Ferraraccio</LastName>
        // <Age>20</Age>
        // <Balance>59.44</Balance>
        // <Tickets>
        //   <Ticket>
        //     <ProjectionId>1</ProjectionId>
        //     <Price>7</Price>
        //   </Ticket>
        //   <Ticket>
        //     <ProjectionId>1</ProjectionId>
        //     <Price>15</Price>
        //   </Ticket>
        //   <Ticket>
    }

    [XmlType("Ticket")]
    public class TicketDto
    {
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }

        [XmlElement("Price")]
        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
