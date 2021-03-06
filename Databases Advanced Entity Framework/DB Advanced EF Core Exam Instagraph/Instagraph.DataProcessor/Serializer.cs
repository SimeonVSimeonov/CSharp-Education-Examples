﻿using Instagraph.Data;
using Instagraph.DataProcessor.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts.Where(p => p.Comments.Count == 0)
                .Select(x => new {
                    Id = x.Id,
                    Picture = x.Picture.Path,
                    User = x.User.Username
                })
                .OrderBy(c => c.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(posts, Formatting.Indented);
            
            return jsonResult;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Include(p => p.Posts)
                .ThenInclude(c => c.Comments)
                .Where(p => p.Posts.Any(c => c.Comments.Any(f => p.Followers.Select(x => x.Follower.Username)
                .Contains(f.User.Username))))
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    x.Username,
                    Followers = x.Followers.Count
                })
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(users, Formatting.Indented);
            
            return jsonResult;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var result = new StringBuilder();

            var users = context.Users
                .Include(u => u.Posts)
                .ThenInclude(p => p.Comments)
                .Select(u => new
                {
                    u.Username,
                    bestPost = u.Posts.Select(c => c.Comments.Count).OrderByDescending(x => x).ToList()
                })
                .ToList();

            var export = new List<ExportCommentDto>();

            foreach (var user in users)
            {
                var exportUser = new ExportCommentDto
                {
                    Username = user.Username,
                    MostComments = user.bestPost.Any() ? user.bestPost[0] : 0
                };

                export.Add(exportUser);
            }

            export = export.OrderByDescending(x => x.MostComments).ThenBy(x => x.Username).ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCommentDto>), new XmlRootAttribute("users"));

            serializer.Serialize(new StringWriter(result), export, Namespaces);

            return result.ToString().TrimEnd();
        }
    }
}
