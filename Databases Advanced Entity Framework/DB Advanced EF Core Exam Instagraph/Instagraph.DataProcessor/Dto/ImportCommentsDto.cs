using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Dto
{
    [XmlType("comment")]
    public class ImportCommentsDto
    {
        [XmlElement("content")]
        public string Content { get; set; }

        [XmlElement("user")]
        public string User { get; set; }

        [XmlElement("post")]
        public commentDto commentDto { get; set; }

        //	<comment> 
        //<content>Wow! Wow, epic!! How?</content>
        //<user>RoundAntigaBel</user>
        //<post id = "22" />
        //
        //</ comment >
    }

    
    public class commentDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
