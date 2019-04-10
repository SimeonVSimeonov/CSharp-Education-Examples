using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Instagraph.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        //•	Id – an integer, Primary Key
        //•	Content – a stringwithmaxlength250
        //•	UserId – an integer
        //•	User – a User
        //•	PostId – an integer
        //•	Post– a Post
        //
    }
}
