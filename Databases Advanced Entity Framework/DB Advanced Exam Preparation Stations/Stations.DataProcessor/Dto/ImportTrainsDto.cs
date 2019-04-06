using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class ImportTrainsDto
    {
        public string TrainNumber { get; set; }

        public string Type { get; set; }

        public ICollection<SeatsDto> Seats { get; set; }



        //    "TrainNumber": "KB20012",
        //"Type": "HighSpeed",
        //"Seats": [
        //  {
        //    "Name": "First class",
        //    "Abbreviation": "FC",
        //    "Quantity": 50
        //  },
        //  {
        //    "Name": "Business class",
        //    "Abbreviation": "BC",
        //    "Quantity": 44
        //  }
        //]
    }

    public class SeatsDto
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public int? Quantity { get; set; }
    }
}
