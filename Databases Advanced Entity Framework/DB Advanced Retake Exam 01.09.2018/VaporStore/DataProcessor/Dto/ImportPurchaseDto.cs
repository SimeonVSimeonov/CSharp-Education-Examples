using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        //No need validation[anotation] its don its valid game name(chek if exists)
        //but need use IsValid Method before import in database
        [XmlAttribute("title")]
        public string Title { get; set; }

        //No need validation [anotation] its don its valid Type (chek if exists)
        //but need use IsValid Method before import in database
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"^(?<productKey>[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4})$")]
        public string Key { get; set; }

        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }


        //<Purchase title = "Dungeon Warfare 2" >
        //< Type > Digital </ Type >
        //< Key > ZTZ3 - 0D2S-G4TJ</Key>
        //<Card>1833 5024 0553 6211</Card>
        //<Date>07/12/2016 05:49</Date>
        //</Purchase>
    }
}
