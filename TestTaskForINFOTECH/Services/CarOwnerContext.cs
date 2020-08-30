using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskForINFOTECH.Models;

namespace TestTaskForINFOTECH.Services
{
    public class CarOwnerContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public CarOwnerContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarOwner>()
                .HasKey(t => new { t.CarId, t.OwnerId });

            modelBuilder.Entity<CarOwner>()
                .HasOne(sc => sc.Car)
                .WithMany(s => s.CarOwners)
                .HasForeignKey(sc => sc.CarId);

            modelBuilder.Entity<CarOwner>()
                .HasOne(sc => sc.Owner)
                .WithMany(c => c.CarOwners)
                .HasForeignKey(sc => sc.OwnerId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InfoTech_db;Trusted_Connection=True;");
        }
    }
}
