using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersAndPrisoners
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Money")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        public PrisonersDto[] Prisoners { get; set; }

        //<Officer>
        //<Name>Paddy Weiner</Name>
        //<Money>2854.56</Money>
        //<Position>Guard</Position>
        //<Weapon>ChainRifle</Weapon>
        //<DepartmentId>3</DepartmentId>
        //<Prisoners>
        //	<Prisoner id = "4" />
        //
        //    < Prisoner id= "1" />
        //
        //</ Prisoners >
        //
        //</ Officer >
    }

    [XmlType("Prisoner")]
    public class PrisonersDto
    {
        [XmlAttribute("id")]
        public int Prisoner { get; set; }
    }
}
