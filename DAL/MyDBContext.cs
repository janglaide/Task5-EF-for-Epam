using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MyDBContext : DbContext
    {
        private const string _connection = "Server=(localdb)\\mssqllocaldb;Database=task5-EF;Trusted_Connection=True;";
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public MyDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasOne(p => p.City)
                .WithMany(x => x.Suppliers)
                .HasForeignKey(f => f.CityId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(f => f.CategoryId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(f => f.SupplierId);

            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City{Id = 1, Name = "Kyiv"},
                new City{Id = 2, Name = "Odesa"},
                new City{Id = 3, Name = "Lviv"}
            });
            modelBuilder.Entity<Supplier>().HasData(new Supplier[]
            {
                new Supplier{Id = 1, Name = "Odesa-Fish", CityId = 2},
                new Supplier{Id = 2, Name = "Galychyna", CityId = 3},
                new Supplier{Id = 3, Name = "Kyiv Bread", CityId = 1},
                new Supplier{Id = 4, Name = "KPI", CityId = 1},
                new Supplier{Id = 5, Name = "EPAM", CityId = 1}
            });
            modelBuilder.Entity<Category>().HasData(new Category[] 
            {
                new Category{Id = 1, Name = "drinks"},
                new Category{Id = 2, Name = "dairy"},
                new Category{Id = 3, Name = "meat"},
                new Category{Id = 4, Name = "fish"},
                new Category{Id = 5, Name = "bakery"}
            });
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product{Id = 1, Name = "Tuna", CategoryId = 4, SupplierId = 1},
                new Product{Id = 2, Name = "Tuna", CategoryId = 4, SupplierId = 4},
                new Product{Id = 3, Name = "Donut", CategoryId = 5, SupplierId = 3},
                new Product{Id = 4, Name = "Milk", CategoryId = 2, SupplierId = 2},
                new Product{Id = 5, Name = "Yogurt", CategoryId = 2, SupplierId = 2},
                new Product{Id = 6, Name = "Milk", CategoryId = 2, SupplierId = 5},
                new Product{Id = 7, Name = "Red caviar", CategoryId = 4, SupplierId = 1},
                new Product{Id = 8, Name = "Red caviar", CategoryId = 4, SupplierId = 5},
                new Product{Id = 9, Name = "Sousages", CategoryId = 3, SupplierId = 4},
                new Product{Id = 10, Name = "White bread", CategoryId = 5, SupplierId = 3},
                new Product{Id = 11, Name = "Black bread", CategoryId = 5, SupplierId = 3},
                new Product{Id = 12, Name = "Baguette", CategoryId = 5, SupplierId = 3},
                new Product{Id = 13, Name = "Baguette", CategoryId = 5, SupplierId = 4},
                new Product{Id = 14, Name = "Fanta", CategoryId = 1, SupplierId = 4},
                new Product{Id = 15, Name = "Sparkling water", CategoryId = 1, SupplierId = 5}
            });
        }
    }
}
