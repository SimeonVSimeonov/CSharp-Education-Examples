using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Models
{
    public class User
    {
        public User()
        {
            this.PaymentMethods = new HashSet<PaymentMethod>();
        }

        public int UserId { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; } //(up to 50 characters, unicode)

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; } //(up to 50 characters, unicode)

        [Required]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9]" +
            ")?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
        public string Email { get; set; } //(up to 80 characters, non-unicode)

        [Required]
        [MinLength(6), MaxLength(20)]
        public string Password { get; set; }//(up to 25 characters, non-unicode)

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
