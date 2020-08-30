using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskForINFOTECH.Models;

namespace TestTaskForINFOTECH.Services
{
    public class CarOwnerRepository
    {
        CarOwnerContext context;
        public CarOwnerRepository()
        {
        }
        public CarOwnerRepository(CarOwnerContext context)
        {
            this.context = context;
        }

        public virtual List<Car> GetAllCars()
        {
            return context.Cars.ToList<Car>();
        }
        public virtual List<Owner> OwnersByCar (string carNumber)
        {
            return context.Owners.Select(o => o).Where(o => o.CarOwners.Any(c => c.CarId == context.Cars.First(p => p.CarNumber == carNumber).Id)).ToList();
        }
        public virtual List<Car> CarsByOwner (Owner owner)
        {
            return context.Cars.Select(c=>c).Where(o=>o.CarOwners.Any(co=>co.Owner==owner)).ToList();
        }
    }
}
