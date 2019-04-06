using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class Vet
    {
        public Vet()
        {
            this.Procedures = new HashSet<Procedure>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }

        [Required]
        [Range(22, 65)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"/(\+)?(359|0)8[789]\d{1}(|-| )\d{3}(|-| )\d{3}/")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; }

        //-	Id – integer, Primary Key
        //-	Name –text with min length 3 and max length 40 (required)
        //-	Profession– text with min length 3 and max length 50 (required)
        //-	Age – integer number, minimum value of 22 years and maximum 65 (required)
        //-	PhoneNumber–required, unique, makesure it matches oneofthe following requirements:
        //«	either starts with +359and is followed by9 digits
        //«	or consists of exactly10 digits, starting with 0
        //-	Procedures– the procedures, performed by the vet

    }
}
