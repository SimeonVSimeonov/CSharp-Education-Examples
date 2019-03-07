using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Sale> Sales { get; set; }

        DbSet<Store> Stores { get; set; }

        DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO Configure DB
            optionsBuilder.UseSqlServer(Config.ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingProduct(modelBuilder);

            OnModelCreatingCustomer(modelBuilder);

            OnModelCreatingStore(modelBuilder);

            OnModelCreatingSale(modelBuilder);
        }

        private void OnModelCreatingSale(ModelBuilder modelBuilder)
        {
            modelBuilder
				.Entity<Sale>()
				.HasKey(s => s.SaleId);
			  
			modelBuilder
				.Property(s => s.Date)
				.HasDefaultValueSql("GETDATE()");
        }

        private void OnModelCreatingStore(ModelBuilder modelBuilder)
        {
            modelBuilder
				.Entity<Store>()
				.HasKey(s => s.StoreId);

            modelBuilder
               .Entity<Store>()
               .Property(s => s.Name)
               .HasMaxLength(80)
               .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);

        }

        private void OnModelCreatingCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Customer>()
               .HasKey(c => c.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);

            modelBuilder
				.Entity<Customer>()
				.HasMany(c => c.Sales)
				.WithOne(s => s.Customer);

        }

        private void OnModelCreatingProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
				.Entity<Product>()
				.Property(d => d.Description)
				.HasMaxLength(250);

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Product);
        }
    }
}
