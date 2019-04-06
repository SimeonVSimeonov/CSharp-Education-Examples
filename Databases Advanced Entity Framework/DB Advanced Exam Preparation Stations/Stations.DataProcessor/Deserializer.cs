using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto;
using Stations.Models;
using Stations.Models.Enums;

namespace Stations.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
            
            var stationsDto = JsonConvert.DeserializeObject<ImportStationsDto[]>(jsonString);
            
            var stations = new List<Station>();

            var sb = new StringBuilder();

            foreach (var stationDto in stationsDto)
            {
                if (stationDto.Town == null)
                {
                    stationDto.Town = stationDto.Name;
                };

                if (!IsValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (stations.Any(s => s.Name == stationDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var station = new Station
                {
                    Name = stationDto.Name,
                    Town = stationDto.Town
                };

                stations.Add(station);
                sb.AppendLine(String.Format(SuccessMessage, stationDto.Name));
            }

            context.Stations.AddRange(stations);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
            var classesDto = JsonConvert.DeserializeObject<ImportClassesDto[]>(jsonString);

            var classes = new List<SeatingClass>();

            var sb = new StringBuilder();

            foreach (var classDto in classesDto)
            {
                if (classes.Any(x => x.Name == classDto.Name) ||
                    classes.Any(x => x.Abbreviation == classDto.Abbreviation))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (!IsValid(classDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var importClass = new SeatingClass
                {
                    Name = classDto.Name,
                    Abbreviation = classDto.Abbreviation
                };


                classes.Add(importClass);
                sb.AppendLine(String.Format(SuccessMessage, importClass.Name));
            }

            context.SeatingClasses.AddRange(classes);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
            var trainsDto = JsonConvert.DeserializeObject<ImportTrainsDto[]>(jsonString);
            
            var trains = new List<Train>();
            
            var trainSeats = new List<TrainSeat>();
           
            var classes = context.SeatingClasses.ToArray();

            var sb = new StringBuilder();

            foreach (var trainDto in trainsDto)
            {
                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                if (trainDto.Seats == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (trainDto.TrainNumber == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type =
                    trainDto.Type == null ? TrainType.HighSpeed : (TrainType)Enum.Parse(typeof(TrainType), trainDto.Type);

                var train = new Train
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = type,

                };

                foreach (var seatDto in trainDto.Seats)
                {
                    var classe = classes.SingleOrDefault(x => x.Name == seatDto.Name &&
                    x.Abbreviation == seatDto.Abbreviation);

                    trainSeats.Add(new TrainSeat
                    {
                        Quantity = seatDto.Quantity.GetValueOrDefault(),
                        SeatingClass = classe,
                        Train = train
                    });

                }

                trains.Add(train);
                sb.AppendLine(String.Format(SuccessMessage, trainDto.TrainNumber));
            }
            ;
            context.Trains.AddRange(trains);
            context.TrainSeats.AddRange(trainSeats);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
			throw new NotImplementedException();
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