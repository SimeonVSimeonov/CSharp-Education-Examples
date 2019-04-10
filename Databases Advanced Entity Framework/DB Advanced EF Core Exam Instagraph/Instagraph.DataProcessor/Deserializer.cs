using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;
using Instagraph.DataProcessor.Dto;
using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
using System.Xml.Serialization;
using System.IO;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
			var picturesDto = JsonConvert.DeserializeObject<ImportPicturesDto[]>(jsonString);
            
            var pictures = new List<Picture>();

            var sb = new StringBuilder();

            foreach (var picDto in picturesDto)
            {
                if (picDto.Size <= 0 || string.IsNullOrEmpty(picDto.Path))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                foreach (var pic in pictures)
                {
                    if (pic.Path == picDto.Path)
                    {
                        sb.AppendLine("Error: Invalid data.");
                        continue;
                    }
                }

                var picture = new Picture
                {
                    Path = picDto.Path,
                    Size = picDto.Size
                };

                pictures.Add(picture);
                sb.AppendLine($"Successfully imported Picture {picDto.Path}.");
            }
            
            context.Pictures.AddRange(pictures);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;

        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

            var users = new List<User>();
            
            var sb = new StringBuilder();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || string.IsNullOrEmpty(userDto.ProfilePicture) ||
                    userDto.Username == null || userDto.Password == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                foreach (var impUser in users)
                {
                    if (impUser.Username == userDto.Username)
                    {
                        sb.AppendLine("Error: Invalid data.");
                        continue;
                    }
                }

                var user = new User
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    ProfilePicture = new Picture {
                        Path = userDto.ProfilePicture
                    }
                    
                };

                users.Add(user);
                sb.AppendLine($"Successfully imported User {userDto.Username}.");

            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var usersFollowersDto = JsonConvert.DeserializeObject<ImportFollowersDto[]>(jsonString);

            var usersFollowers = new List<UserFollower>();
            
            var sb = new StringBuilder();

            var allUsers = context.Users.ToList();
            
            foreach (var userFollowerDto in usersFollowersDto)
            {
                var follower = GetFollower(context, userFollowerDto.Follower);
                var user = GetUser(context, userFollowerDto.User);

                if (follower == null || user == null || usersFollowers.Any(x => x.User.Username == user.Username &&
                                                                           x.Follower.Username == follower.Username))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var userFoll = new UserFollower
                {
                    Follower = follower,
                    User = user
                };

                usersFollowers.Add(userFoll);
                sb.AppendLine($"Successfully imported Follower {follower.Username} to User {user.Username}.");
            }

            context.UsersFollowers.AddRange(usersFollowers.Distinct());
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPostsDto[]), new
               XmlRootAttribute("posts"));

            var postsDto = (ImportPostsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            
            var posts = new List<Post>();

            var sb = new StringBuilder();

            foreach (var postDto in postsDto)
            {
                var user = GetUser(context, postDto.User);
                var picture = context.Pictures.FirstOrDefault(x => x.Path == postDto.Picture);

                if (user == null || picture == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                posts.Add(new Post
                {
                    Caption = postDto.Caption,
                    User = user,
                    Picture = picture
                });

                sb.AppendLine($"Successfully imported Post {postDto.Caption}.");
            }
            
            context.Posts.AddRange(posts);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;

        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCommentsDto[]), new
              XmlRootAttribute("comments"));

            var commentsDto = (ImportCommentsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var comments = new List<Comment>();
            var posts = new List<Post>();
            
            var sb = new StringBuilder();

            foreach (var commDto in commentsDto)
            {
                if (commDto.commentDto == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }


                var user = GetUser(context, commDto.User);
                var post = context.Posts.FirstOrDefault(x => x.Id == commDto.commentDto.Id);

                if (user == null || post == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var comment = new Comment
                {
                    Content = commDto.Content,
                    User = user,
                    Post = post
                };

                posts.Add(post);

                comments.Add(comment);

                sb.AppendLine($"Successfully imported Comment {comment.Content}.");
            };
            
            context.Comments.AddRange(comments);
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

        private static User GetUser(InstagraphContext context, string userDto)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == userDto);

            return user;
        }

        private static User GetFollower(InstagraphContext context, string followerDto)
        {
            var follower = context.Users.FirstOrDefault(x => x.Username == followerDto);

            return follower;
        }
    }
}
