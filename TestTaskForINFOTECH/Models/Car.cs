using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskForINFOTECH.Models
{
    public class Car
    {
        public Car()
        {
            CarOwners = new List<CarOwner>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 3)]
        public string CarNumber { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int YearOfIssue { get; set; }
        public List<CarOwner> CarOwners { get; set; }
    }
}
