using System;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.Model
{
    public class CarServiceContext:DbContext
    {
        public CarServiceContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarStore> CarStores { get; set; } = null!;
        public DbSet<Characteristic> Characteristics { get; set; } = null!;
        public DbSet<Cost> Costs { get; set; } = null!;
        public DbSet<Detail> Details { get; set; } = null!;
        public DbSet<DetailStore> DetailStores { get; set; } = null!;
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CarService;User Id=sa;Password=Valuetech@123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Characteristics)
                .WithOne(ch => ch.Car)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarStore>()
                .HasOne(cs => cs.Car)
                .WithOne(c => c.CarStore)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Cost)
                .WithOne(c => c.Detail)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Basket)
                .WithOne(c => c.Detail)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetailStore>()
                .HasOne(ds => ds.Detail)
                .WithOne(d => d.DetailStore)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

