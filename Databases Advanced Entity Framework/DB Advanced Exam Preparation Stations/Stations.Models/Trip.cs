using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Stations.Models.Enums;

namespace Stations.Models
{
    public class Trip
    {
        public int Id { get; set; }

        [Required]
        public int OriginStationId { get; set; }
        public Station OriginStation { get; set; }// TODO check for required???

        [Required]
        public int DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }// TODO check for required???

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int TrainId { get; set; }
        public Train Train { get; set; }// TODO check for required???

        public TripStatus Status { get; set; }

        public TimeSpan? TimeDifference { get; set; }


        //•	Id– integer, Primary Key
        //•	OriginStationId – integer(required)
        //•	OriginStation – station from which the trip begins(required)
        //•	DestinationStationId – integer(required)
        //•	DestinationStation–station where the trip ends(required)
        //•	DepartureTime –date and time of departure from origin station(required)
        //•	ArrivalTime– date and time of arrival at destination station, must be after departure time(required)
        //•	TrainId – integer(required)
        //•	Train– train used for that particular trip(required)
        //•	Status– TripStatus enumeration with possible values: "OnTime", "Delayed" and "Early" (default: "OnTime")
        //•	TimeDifference–time(span)representing how late or earlya given train was(optional)

    }
}
