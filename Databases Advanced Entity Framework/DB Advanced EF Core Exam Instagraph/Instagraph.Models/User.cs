using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Instagraph.Models
{
    public class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Followers = new HashSet<UserFollower>();
            this.UsersFollowing = new HashSet<UserFollower>();
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

       
        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public int ProfilePictureId { get; set; }
        public Picture ProfilePicture { get; set; }

        public ICollection<UserFollower> Followers { get; set; }

        public ICollection<UserFollower> UsersFollowing { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }

        //•	Id – an integer, Primary Key
        //•	Username–a stringwith max length 30, Unique
        //•	Password– a stringwith max length 20
        //•	ProfilePictureId – an integer
        //•	ProfilePicture – a Picture
        //•	Followers–a Collection of type UserFollower
        //•	UsersFollowing– a Collection of type UserFollower
        //•	Posts– a Collection of type Post
        //•	Comments– a Collection of type Comment

    }
}
