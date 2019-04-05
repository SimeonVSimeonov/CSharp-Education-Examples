using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            this.PrisonerOfficers = new HashSet<OfficerPrisoner>();
            this.Mails = new HashSet<Mail>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("The [A-Z]{1}[a-z]*")]
        public string Nickname { get; set; }

        [Required]
        [Range(18,65)]
        public int Age { get; set; }

        [Required]
        public DateTime IncarcerationDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        
        public int? CellId { get; set; }     
        public Cell Cell { get; set; }

        public ICollection<Mail> Mails { get; set; }

        public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }

        //•	Id– integer, Primary Key
        //•	FullName –text withmin length3 and max length 20(required)
        //•	Nickname – textstarting with "The " and asingle word only of letters with anuppercase letter for beginning(example: The Prisoner)(required)
        //•	Age– integerin the range[18, 65] (required)
        //•	IncarcerationDate¬–Date(required)
        //•	ReleaseDate–Date
        //•	Bail–decimal (non-negative, minimum value: 0)
        //•	CellId - integer, foreign key
        //•	Cell – the prisoner's cell
        //•	Mails - collection of type Mail
        //•	PrisonerOfficers - collection of type OfficerPrisoner

    }
}