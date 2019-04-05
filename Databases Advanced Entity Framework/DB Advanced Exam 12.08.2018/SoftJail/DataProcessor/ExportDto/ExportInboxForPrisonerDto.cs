﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportInboxForPrisonerDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        public EncryptedMessagesDto[] EncryptedMessages { get; set; }

        //<Prisoner>
        //<Id>3</Id>
        //<Name>Binni Cornhill</Name>
        //<IncarcerationDate>1967-04-29</IncarcerationDate>
        //<EncryptedMessages>
        //<Message>
        //<Description>!?sdnasuoht evif-ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
        //</Message>
        //</EncryptedMessages>
        //</Prisoner>
        //
    }

    [XmlType("Message")]
    public class EncryptedMessagesDto
    {
        [XmlElement("Message")]
        public string Message { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
