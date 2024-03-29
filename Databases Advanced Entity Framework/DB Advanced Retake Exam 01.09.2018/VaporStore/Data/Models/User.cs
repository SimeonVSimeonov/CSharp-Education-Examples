﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?<name>[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+)$")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<Card> Cards { get; set; }

        //•	Id– integer, Primary Key
        //•	Username – text with length[3, 20] (required)
        //•	FullName – text, which has two words, consisting of Latin letters.Both startwith an upper letter and are separated by a single space(ex."John Smith")(required)
        //•	Email – text(required)
        //•	Age–integer in the range[3, 103](required)
        //•	Cards–collection of type Card
    }
}
