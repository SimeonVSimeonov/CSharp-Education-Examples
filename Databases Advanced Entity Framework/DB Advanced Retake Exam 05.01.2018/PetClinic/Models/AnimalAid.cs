﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class AnimalAid
    {
        public AnimalAid()
        {
            this.AnimalAidProcedures = new HashSet<ProcedureAnimalAid>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; }

        //-	Id – integer, Primary Key
        //-	Name – text with min length 3 and max length 30 (required, unique)
        //-	Price – decimal (non-negative, minimum value: 0.01, required)
        //-	AnimalAidProcedures–collection of type ProcedureAnimalAid

    }
}
