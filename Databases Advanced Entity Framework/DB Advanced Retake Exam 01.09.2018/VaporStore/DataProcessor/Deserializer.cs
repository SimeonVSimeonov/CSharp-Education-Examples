namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var games = new List<Game>();

            var sb = new StringBuilder();

            foreach (var gameDto in gamesDto)
            {
                //validate data for import
                if (!IsValid(gameDto) || gameDto.Tags.Count <= 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //create game
                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate
                };

                //If a developer/genre/tag with that name doesn’t exist, create it
                //var developer = GetDeveloper(context, gameDto.Developer);
                var developer = GetDeveloper(context, gameDto.Developer);
                var genre = GetGenre(context, gameDto.Genre);

                game.Developer = developer;
                game.Genre = genre;

                //every game have many tags
                foreach (var currentTag in gameDto.Tags)
                {
                    var tag = GetTag(context, currentTag);

                    game.GameTags.Add(new GameTag
                    {
                        Game = game, //in each case?
                        Tag = tag
                    });
                }

                //add game to collection
                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            var sb = new StringBuilder();

            foreach (var userDto in usersDto)
            {
                //validation data
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //validation CardType data
                bool isValidEnum = true;
                foreach (var cardDto in userDto.Cards)
                {
                    var cardType = Enum.TryParse<CardType>(cardDto.Type, out CardType testCard);

                    if (!cardType)
                    {
                        isValidEnum = false;
                        break;
                    }
                }

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Age = userDto.Age,
                    Email = userDto.Email,
                };

                foreach (var cardDto in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new
                XmlRootAttribute("Purchases"));

            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();

            var sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                //validate data
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //validate data enum
                var isValidEnum = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType validPurchaseType);

                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //check game and card exist before insert in database
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (game == null || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                //create obj now if we dont remember what to use check original model
                var purchase = new Purchase
                {
                    Type = validPurchaseType,
                    //date in Dto is string use Parse
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Game = game
                };
                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        //Private Methods
        //check if exists if not create then return
        private static Tag GetTag(VaporStoreDbContext context, string currentTag)
        {
            var tag = context.Tags.FirstOrDefault(t => t.Name == currentTag);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = currentTag
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

        //check if exists if not create then return
        private static Genre GetGenre(VaporStoreDbContext context, string genreNameDto)
        {
            var genre = context.Genres.FirstOrDefault(g => g.Name == genreNameDto);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = genreNameDto
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        //check if exists if not create then return
        private static Developer GetDeveloper(VaporStoreDbContext context, string developerNameDto)
        {
            var developer = context.Developers.FirstOrDefault(d => d.Name == developerNameDto);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = developerNameDto
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
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