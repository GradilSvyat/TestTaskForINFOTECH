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
            var car = context.Cars.First(p => p.CarNumber == carNumber).Id;
            var owners = context.Owners.Include(cw => cw.CarOwners).ThenInclude(c => c.Car).ToList();
            List<Owner> result = new List<Owner>();
            foreach(Owner own in owners)
            {
                if (own.CarOwners.Any(c => c.CarId == car))
                    result.Add(own);
            }
            return result;
        }
    }
}
