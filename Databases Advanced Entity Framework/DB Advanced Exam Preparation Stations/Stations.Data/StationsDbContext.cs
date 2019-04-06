using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
    public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<CustomerCard> Cards { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            //Delete behavior ana PK
            //and PK for two key to same tabel
            modelBuilder.Entity<Trip>()
                 .HasOne(x => x.OriginStation)
                 .WithMany(x => x.TripsFrom)
                 .HasForeignKey(e => e.OriginStationId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                 .HasOne(x => x.DestinationStation)
                 .WithMany(x => x.TripsTo)
                 .HasForeignKey(e => e.DestinationStationId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                .HasOne(x => x.Train)
                .WithMany(x => x.Trips)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainSeat>()
                .HasOne(x => x.Train)
                .WithMany(x => x.TrainSeats)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Trip);

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.CustomerCard)
                .WithMany(x => x.BoughtTickets)
                .OnDelete(DeleteBehavior.Restrict);

            //validate for unique
            modelBuilder.Entity<SeatingClass>()
                .HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<SeatingClass>()
                .HasIndex(x => x.Abbreviation).IsUnique();

            modelBuilder.Entity<Station>()
                .HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Train>()
                .HasIndex(x => x.TrainNumber).IsUnique();
        }
	}
}