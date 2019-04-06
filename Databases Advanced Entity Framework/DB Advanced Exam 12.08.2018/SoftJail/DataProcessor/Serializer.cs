namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            //Export all prisoners that were processed which have these ids
            //get their id,name, cell number they are placed in,
            //officers with each officername, and the department name
            //export the total officer salary with exactly two digits after the decimal place
            //officers and theprisoners by their name (ascending), then by the prisoner id(ascending)

            var prisoners = context.Prisoners
                .Where(i => ids.Contains(i.Id))
                .Select(p => new {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Where(o => o.PrisonerId == p.Id)
                    .Select(x => new {
                        OfficerName = x.Officer.FullName,
                        Department = x.Officer.Department.Name
                    })
                    .OrderBy(x => x.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(x => x.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();
            
            var jsonResult = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            //receives a string of comma-separated prisoner names. Export the prisoners:
            //for each prisoner, export itsid,name, incarcerationDatein the format “yyyy-MM-dd” 
            //and their encrypted mails. The encrypted algorithm you have to use is just to take
            //each prisoner mail description and reverse it.Sort the prisoners by their name (ascending),
            //then by their id (ascending).
            var spliInput = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                .Where(x => spliInput.Contains(x.FullName))
                .Select(p => new ExportInboxForPrisonerDto
                {

                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails.Select(m => new EncryptedMessagesDto {
                        Description = ReverseDescription(m.Description)//TODO how to reverse string ????????

                    }).ToArray()
                    
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();
            
            
            
            var xmlSerializer = new XmlSerializer(typeof(ExportInboxForPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            var sb = new StringBuilder();
            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static string ReverseDescription(string description)
        {
            return string.Join("", description.Reverse());
        }
    }
}