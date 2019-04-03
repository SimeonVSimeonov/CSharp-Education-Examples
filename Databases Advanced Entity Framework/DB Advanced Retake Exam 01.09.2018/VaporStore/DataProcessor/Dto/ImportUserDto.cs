using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto
{
    //place json prop like a Dto
    //add validation attr(anotation)

    public class ImportUserDto
    {
        [Required]
        [RegularExpression(@"^(?<name>[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+)$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public CardDto[] Cards { get; set; }

        //          {
        //"FullName": "Lorrie Silbert",
        //"Username": "lsilbert",
        //"Email": "lsilbert@yahoo.com",
        //"Age": 33,
        //"Cards": [
        //      {
        //"Number": "1833 5024 0553 6211",
        //"CVC": "903",
        //"Type": "Debit"
        //      },
        //      {
        //"Number": "5625 0434 5999 6254",
        //"CVC": "570",
        //"Type": "Credit"
        //      },
        //      {
        //"Number": "4902 6975 5076 5316",
        //"CVC": "091",
        //"Type": "Debit"
        //      }
        //    ]
        //  },
        //
    }

    public class CardDto
    {
        [Required]
        //[CreditCard]
        [RegularExpression("^[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}$")]
        public string Number { get; set; }

        [Required]         //^[0-9]{3}$
        [RegularExpression(@"^[0-9]{3}")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }

        //"Number": "4902 6975 5076 5316",
        //"CVC": "091",
        //"Type": "Debit"
    }
}
