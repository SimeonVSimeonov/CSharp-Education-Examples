namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2:F2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMoviesDto[]>(jsonString);

            var movies = new List<Movie>();

            var sb = new StringBuilder();

            foreach (var dto in moviesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidGenre = Enum.TryParse<Genre>(dto.Genre,
                            out Genre validGenre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = dto.Title,
                    Genre = validGenre,
                    Duration = dto.Duration,
                    Rating = dto.Rating,
                    Director = dto.Director
                };

                var tl = movies.Select(x => x.Title);

                if (tl.Contains(movie.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, dto.Title, dto.Genre, dto.Rating));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);

            var hallSeats = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var dto in hallsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (dto.Seats < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var hall = new Hall
                {
                    Name = dto.Name,
                    Is4Dx = dto.Is4Dx,
                    Is3D = dto.Is3D
                };

                for (int i = 0; i < dto.Seats; i++)
                {
                    hall.Seats.Add(new Seat { });
                }


                var type = "";

                if (hall.Is4Dx == true && hall.Is3D == true)
                {
                    type = "4Dx/3D";
                }
                else if (hall.Is3D == true)
                {
                    type = "3D";
                }
                else if (hall.Is4Dx == true)
                {
                    type = "4Dx";
                }
                else
                {
                    type = "Normal";
                }

                hallSeats.Add(hall);
                sb.AppendLine($"Successfully imported {dto.Name}({type}) with {dto.Seats} seats!");
            }

            context.Halls.AddRange(hallSeats);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;

        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new
              XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            
            var projections = new List<Projection>();
            var sb = new StringBuilder();

            var movieIds = context.Movies.Select(x => x.Id).ToArray();
            var hallIds = context.Halls.Select(x => x.Id).ToArray();
            
            foreach (var dto in projectionsDto)
            {

                if (!IsValid(dto) || !movieIds.Contains(dto.MovieId) || !hallIds.Contains(dto.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validDate = DateTime.ParseExact(dto.DateTime,
                                        "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                var movie = context.Movies.FirstOrDefault(x => x.Id == dto.MovieId);

                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = validDate,
                };

                var projectionDate = validDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projectionDate));
            }

            context.Projections.AddRange(projections);

            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketsDto[]), new
              XmlRootAttribute("Customers"));

            var customersTicketsDto = (ImportCustomerTicketsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            
            var tickets = new List<Ticket>();
            var customers = new List<Customer>();

            var sb = new StringBuilder();

            foreach (var customerTicketDto in customersTicketsDto)
            {
                if (!IsValid(customerTicketDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerTicketDto.FirstName,
                    LastName = customerTicketDto.LastName,
                    Age = customerTicketDto.Age,
                    Balance = customerTicketDto.Balance
                };

                foreach (var ticketDto in customerTicketDto.Tickets)
                {
                    var ticket = new Ticket {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    };

                    customer.Tickets.Add(ticket);
                }

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customerTicketDto.FirstName, 
                    customerTicketDto.LastName, customerTicketDto.Tickets.Count()));
            }
            
            context.Customers.AddRange(customers);

            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }

        private static Movie GetMovie(CinemaContext context, int dtoId)
        {
            var movie = context.Movies.FirstOrDefault(d => d.Id == dtoId);

            if (movie == null)
            {
                movie = new Movie
                {
                    Id = dtoId
                };

            }

            return movie;
        }

        private static Hall GetHall(CinemaContext context, int hallId)
        {
            var hall = context.Halls.FirstOrDefault(d => d.Id == hallId);

            if (hall == null)
            {
                hall = new Hall
                {
                    Id = hallId
                };

            }

            return hall;
        }
    }
}