namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentCellsDto = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString);

            var departments = new List<Department>();

            var sb = new StringBuilder();

            foreach (var depCellDto in departmentCellsDto)
            {
                if (!IsValid(depCellDto) || !depCellDto.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = depCellDto.Name,
                };

                foreach (var cellDto in depCellDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                departments.Add(department);
                sb.AppendLine($"Imported {depCellDto.Name} with {depCellDto.Cells.Count()} cells");
            }
            
            context.Departments.AddRange(departments);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;

        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMailsDto = JsonConvert.DeserializeObject<PrisonersAndMailsDto[]>(jsonString);
            
            var prisoners = new List<Prisoner>();

            var sb = new StringBuilder();

            foreach (var prisonerAndMailsDto in prisonersMailsDto)
            {
                if (!IsValid(prisonerAndMailsDto)) //|| !prisonerAndMailsDto.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                ;
                var prisoner = new Prisoner
                {
                    FullName = prisonerAndMailsDto.FullName,
                    Nickname = prisonerAndMailsDto.Nickname,
                    Age = prisonerAndMailsDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerAndMailsDto.IncarcerationDate,
                                        "dd/MM/yyyy", CultureInfo.InvariantCulture),

                    //String.IsNullOrEmpty(hire) ? (DateTime?)null : DateTime.Parse(hire)

                    ReleaseDate = String.IsNullOrEmpty(prisonerAndMailsDto.ReleaseDate) ? (DateTime?) null :
                                DateTime.ParseExact(prisonerAndMailsDto.ReleaseDate,
                                        "dd/MM/yyyy", CultureInfo.InvariantCulture),

                    Bail = prisonerAndMailsDto.Bail,
                    CellId = prisonerAndMailsDto.CellId
                };

                foreach (var mailsDto in prisonerAndMailsDto.Mails)
                {
                    prisoner.Mails.Add(new Mail
                    {
                        Description = mailsDto.Description,
                        Sender = mailsDto.Sender,
                        Address = mailsDto.Address
                    });
                }
                
                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisonerAndMailsDto.FullName} {prisonerAndMailsDto.Age} years old");
            }
            
            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersAndPrisoners[]), new
                XmlRootAttribute("Officers"));

            var officersPrisonersDto = (ImportOfficersAndPrisoners[])xmlSerializer.Deserialize(new StringReader(xmlString));
            ;
            var officers = new List<Officer>();

            var sb = new StringBuilder();

            foreach (var officerPrisonerDto in officersPrisonersDto)
            {
                if (!IsValid(officerPrisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidPosition = Enum.TryParse<Position>(officerPrisonerDto.Position,
                    out Position validPosition);

                var isValidWeapon = Enum.TryParse<Weapon>(officerPrisonerDto.Weapon,
                   out Weapon validWeapon);

                if (!isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerPrisonerDto.Name,
                    Salary = officerPrisonerDto.Money,
                    Position = validPosition,
                    Weapon = validWeapon,
                    DepartmentId = officerPrisonerDto.DepartmentId,
                   
                };

                foreach (var prisonerDto in officerPrisonerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisonerDto.Prisoner

                    });
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officerPrisonerDto.Name} ({officerPrisonerDto.Prisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;

        }

        //TODO validator method
        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}