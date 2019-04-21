namespace MusicHub.DataProcessor
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
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using Album = Data.Models.Album;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDtos = JsonConvert.DeserializeObject<ImportWritersDto[]>(jsonString);

            var writers = new List<Writer>();
            var sb = new StringBuilder();

            foreach (var writerDto in writersDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writerDto.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersAlbumsDto = JsonConvert.DeserializeObject<ImportProducersAlbumsDto[]>(jsonString);

            var producers = new List<Producer>();
            var sb = new StringBuilder();

            foreach (var importProducerDto in producersAlbumsDto)
            {
                if (!IsValid(importProducerDto) || importProducerDto.Albums.Any(x => x.Name.Length < 3))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importProducerDto.PhoneNumber == null)
                {

                    var producer = new Producer
                    {
                        Name = importProducerDto.Name,
                        Pseudonym = importProducerDto.Pseudonym,
                    };

                    foreach (var albumDto in importProducerDto.Albums)
                    {
                        if (!IsValid(albumDto) || importProducerDto.Albums.Any(x => x.Name.Length < 3))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                        else
                        {
                            var validDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            producer.Albums.Add(new Album { Name = albumDto.Name, ReleaseDate = validDate });
                        }

                    }

                    producers.Add(producer);
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone,
                        importProducerDto.Name, producer.Albums.Count));
                }
                else
                {
                    var producer = new Producer
                    {
                        Name = importProducerDto.Name,
                        Pseudonym = importProducerDto.Pseudonym,
                        PhoneNumber = importProducerDto.PhoneNumber
                    };

                    foreach (var albumDto in importProducerDto.Albums)
                    {
                        if (!IsValid(albumDto) || importProducerDto.Albums.Any(x => x.Name.Length < 3))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                        else
                        {
                            var validDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            producer.Albums.Add(new Album { Name = albumDto.Name, ReleaseDate = validDate });
                        }

                    }
                    producers.Add(producer);
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, importProducerDto.Name,
                        importProducerDto.PhoneNumber, producer.Albums.Count));
                }

            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new
                    XmlRootAttribute("Songs"));

            var songsDto = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var songs = new List<Song>();
            var sb = new StringBuilder();

            foreach (var songDto in songsDto)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidEnum = Enum.TryParse<Genre>(songDto.Genre, out Genre validGenre);
                var validSpan = TimeSpan.TryParse(songDto.Duration, out TimeSpan time);

                if (!isValidEnum || !validSpan)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writerId = context.Writers.FirstOrDefault(x => x.Id == songDto.WriterId);
                var albumId = context.Albums.FirstOrDefault(x => x.Id == songDto.AlbumId);

                if (writerId == null || albumId == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = time,
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = validGenre,
                    AlbumId = albumId.Id,
                    WriterId = writerId.Id,
                    Price = songDto.Price
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, songDto.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongPerformersDto[]), new
                    XmlRootAttribute("Performers"));

            var songsPerformsDto = (ImportSongPerformersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var performers = new List<Performer>();
            var sb = new StringBuilder();

            foreach (var performerDto in songsPerformsDto)
            {

                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var contextSongsId = context.Songs.Select(x => x.Id).OrderBy(x => x).ToArray();
                var perfSongsId = performerDto.PerformersSongs.Select(x => x.Id).ToArray();

                bool isSubset = perfSongsId.All(elem => contextSongsId.Contains(elem));

                if (!isSubset)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,

                };

                foreach (var song in performerDto.PerformersSongs)
                {
                    performer.PerformerSongs.Add(new SongPerformer { SongId = song.Id });
                }
                
                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performerDto.FirstName,
                    performer.PerformerSongs.Count));
            }
            
            context.Performers.AddRange(performers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        //valid method
        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}