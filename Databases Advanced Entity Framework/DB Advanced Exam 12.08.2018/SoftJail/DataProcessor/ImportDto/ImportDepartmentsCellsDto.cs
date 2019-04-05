using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsCellsDto
    {
        [Required]
        [MinLength(3), MaxLength(25)]
        public string Name { get; set; }
        
        public CellsDto[] Cells { get; set; }
        //        "Name": "Cybersecurity",
        //"Cells": [
        //      {
        //"CellNumber": 101,
        //"HasWindow": true
        //      },
        //      {
        //"CellNumber": 102,
        //"HasWindow": false
        //      },
        //      {
        //"CellNumber": 103,
        //"HasWindow": true
        //      },
        //      {
        //"CellNumber": 104,
        //"HasWindow": false
        //      },
        //      {
        //"CellNumber": 105,
        //"HasWindow": true
        //      }
        //    ]
        //
    }

    public class CellsDto
    {
        [Required]
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}
