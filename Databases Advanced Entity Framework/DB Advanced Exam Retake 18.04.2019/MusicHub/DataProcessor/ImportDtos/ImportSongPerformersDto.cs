using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongPerformersDto
    {
        [XmlElement("FirstName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(18, 70)]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        public PerformersSongs[] PerformersSongs { get; set; }
    }

    [XmlType("Song")]
    public class PerformersSongs
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
