using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class TrainSeat
    {
        public int Id { get; set; }

        [Required]
        public int TrainId { get; set; }
        public Train Train { get; set; } //TODO check for required and here?

        [Required]
        public int SeatingClassId { get; set; }
        public SeatingClass SeatingClass { get; set; }//TODO check for required and here?

        [Required]
        [Range(0, 2147483647)]
        public int Quantity { get; set; }

        //•	Id– integer, Primary Key
        //•	TrainId –integer(required)
        //•	Train–train whose seats will be described(required)
        //•	SeatingClassId–integer(required)
        //•	SeatingClass–class of the seats(required)
        //•	Quantity – how many seats of given class total for the given train(required, non-negative)

    }
}
