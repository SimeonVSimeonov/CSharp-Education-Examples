using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Caption { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        public ICollection<Comment> Comments { get; set; }


        //•	Id – an integer, Primary Key
        //•	Caption – a string
        //•	UserId – an integer
        //•	User – a User
        //•	PictureId – an integer
        //•	Picture– a Picture
        //•	Comments – a Collection of type Comment
        //
    }
}
