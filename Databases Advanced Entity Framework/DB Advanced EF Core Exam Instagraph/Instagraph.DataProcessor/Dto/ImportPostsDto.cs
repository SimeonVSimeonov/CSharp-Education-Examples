using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Dto
{
    [XmlType("post")]
    public class ImportPostsDto
    {

        [XmlElement("caption")]
        public string Caption { get; set; }

        [XmlElement("user")]
        public string User { get; set; }

        [XmlElement("picture")]
        public string Picture { get; set; }

        //	<post>
        //<caption>#everything #fuck #ring #faith #insta #infinity #swag #sunglasses #suzanita #smiley #justdoit #the #sleepless #ocean</caption>
        //<user>ScoreAntigarein</user>
        //<picture>src/folders/resources/images/story/blocked/png/1S2el3wJ3v.png</picture>
        //</post>
    }
}
