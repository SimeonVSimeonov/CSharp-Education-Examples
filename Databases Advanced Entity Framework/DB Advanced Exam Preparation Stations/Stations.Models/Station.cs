using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stations.Models
{
    public class Station
    {
        public Station()
        {
            this.TripsTo = new HashSet<Trip>();
            this.TripsFrom = new HashSet<Trip>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Town { get; set; }

        //[NotMapped]
        public ICollection<Trip> TripsTo { get; set; }
        //[NotMapped]
        public ICollection<Trip> TripsFrom { get; set; }

        //•	Id– integer, Primary Key
        //•	Name – text with max length50(required, unique)
        //•	Town– text with max length50(required)
        //•	TripsTo – Collection of type Trip
        //•	TripsFrom – Collection of type Trip
    }
}
