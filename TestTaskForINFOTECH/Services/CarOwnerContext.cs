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
            if(Database.EnsureCreated())
            {
                using (CarOwnerContext db = new CarOwnerContext())
                {
                    db.Cars.AddRange(GetCars);
                    db.Owners.AddRange(GetOwners);
                    db.SaveChanges();
                    for(int i = 0; i < 8; i++)
                    {
                        GetCars[i].CarOwners.Add(new CarOwner { CarId = GetCars[i].Id, OwnerId = GetOwners[i].Id });
                    }
                    GetCars[8].CarOwners.Add(new CarOwner { CarId = GetCars[8].Id, OwnerId = GetOwners[7].Id });
                    GetCars[9].CarOwners.Add(new CarOwner { CarId = GetCars[9].Id, OwnerId = GetOwners[8].Id });
                    GetCars[9].CarOwners.Add(new CarOwner { CarId = GetCars[9].Id, OwnerId = GetOwners[9].Id });
                    db.SaveChanges();
                }
            }
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

        private Car[] GetCars = new Car[]
        {
            new Car
            {
                Brand = "BMW",
                Model = "M5",
                CarNumber = "AA0000AA",
                VIN = "NNBBVVCCXX9876543",
                Color = "Gray",
                YearOfIssue = 2015
            },
            new Car
            {
                Brand = "Toyota",
                Model = "Yaris",
                CarNumber = "BC1111CB",
                VIN = "ZZXXCCVVBB1234567",
                Color = "Blue",
                YearOfIssue = 2018
            },
            new Car
            {
                Brand = "Ford",
                Model = "Mondeo",
                CarNumber = "BM2222MB",
                VIN = "AASSDDFFGG0987654",
                Color = "Red",
                YearOfIssue = 2010
            },
            new Car
            {
                Brand = "Renault",
                Model = "Logan",
                CarNumber = "AA6034OK",
                VIN = "AAABBBZZZ00987654",
                Color = "White",
                YearOfIssue = 2014
            },
            new Car
            {
                Brand = "Ford",
                Model = "Mondeo",
                CarNumber = "KA7788OX",
                VIN = "BBBAAAXXX00847362",
                Color = "Grey",
                YearOfIssue = 2018
            },
            new Car
            {
                Brand = "Toyota",
                Model = "Corolla",
                CarNumber = "BC9876KT",
                VIN = "DDFFHHJJKK0987654",
                Color = "Blue",
                YearOfIssue = 2010
            },
            new Car
            {
                Brand = "BMW",
                Model = "i3",
                CarNumber = "CB1234AC",
                VIN = "VVBBNNMMCC1234567",
                Color = "Green",
                YearOfIssue = 2019
            },
            new Car
            {
                Brand = "Audi",
                Model = "Q7",
                CarNumber = "AC7654AC",
                VIN = "PPOOIIUUYY4352873",
                Color = "Black",
                YearOfIssue = 2013
            },
            new Car
            {
                Brand = "Peugeot",
                Model = "108",
                CarNumber = "AH7483BX",
                VIN = "HDJSNCHYFB7492650",
                Color = "Yellow",
                YearOfIssue = 2017
            },
            new Car
            {
                Brand = "Fiat",
                Model = "Doblo",
                CarNumber = "BB8473TC",
                VIN = "SKVYBNEHCY4795725",
                Color = "Gray",
                YearOfIssue = 2009
            }
        };
        private Owner[] GetOwners = new Owner[]
        {
            new Owner
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Surname = "Ivanovich",
                IdentificationNumber = "1234567890",
                DateOfBirth = new DateTime(1995, 4, 4)
            },
            new Owner
            {
                FirstName = "Alex",
                LastName = "Alexeenko",
                Surname = "Alexeevich",
                IdentificationNumber = "0987654321",
                DateOfBirth = new DateTime(1990, 1, 1)
            },
            new Owner
            {
                FirstName = "Vasil",
                LastName = "Vasilenko",
                Surname = "Vasiliiovich",
                IdentificationNumber = "0011223344",
                DateOfBirth = new DateTime(1990, 7, 3)
            },
            new Owner
            {
                FirstName = "Peter",
                LastName = "Petrenko",
                Surname = "Petrovich",
                IdentificationNumber = "9988776655",
                DateOfBirth = new DateTime(1980, 5, 5)
            },
            new Owner
            {
                FirstName = "Alexandr",
                LastName = "Alexandrov",
                Surname = "Alexandrovich",
                IdentificationNumber = "0987654321",
                DateOfBirth = new DateTime(1992, 2, 2)
            },
            new Owner
            {
                FirstName = "Mark",
                LastName = "Marchenko",
                Surname = "Markovich",
                IdentificationNumber = "0099887766",
                DateOfBirth = new DateTime(1993, 3, 3)
            },
            new Owner
            {
                FirstName = "Kate",
                LastName = "Vasiliiva",
                Surname = "Vasiliivna",
                IdentificationNumber = "8305826184",
                DateOfBirth = new DateTime(1994, 4, 4)
            },
            new Owner
            {
                FirstName = "Lidia",
                LastName = "Levchenko",
                Surname = "Ivanovna",
                IdentificationNumber = "3850093847",
                DateOfBirth = new DateTime(1995, 5, 5)
            },
            new Owner
            {
                FirstName = "Natalia",
                LastName = "Koval",
                Surname = "Viktorovna",
                IdentificationNumber = "7459430374",
                DateOfBirth = new DateTime(1996, 6, 6)
            },
            new Owner
            {
                FirstName = "Mary",
                LastName = "Volodenko",
                Surname = "Artemovna",
                IdentificationNumber = "6593047583",
                DateOfBirth = new DateTime(1997, 7, 7)
            }
        };
    }
}
