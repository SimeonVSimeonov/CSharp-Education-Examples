using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Instagraph.Data
{
    public class InstagraphContext : DbContext
    {
        public InstagraphContext() { }

        public InstagraphContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFollower> UsersFollowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollower>().HasKey(x => new { x.UserId, x.FollowerId });

            //modelBuilder.Entity<User>()
            //    .Property(u => u.Username)
            //    .HasMaxLength(30)
            //    .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            //modelBuilder.Entity<User>()
            //    .Property(u => u.Password)
            //    .HasMaxLength(20)
            //    .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithOne(uf => uf.User)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UsersFollowing)
                .WithOne(uf => uf.Follower)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Post>()
            //    .HasMany(x => x.Comments)
            //    .WithOne(x => x.Post)
            //    .HasForeignKey(x => x.PostId);
        }
    }
}
