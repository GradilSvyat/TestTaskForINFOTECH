using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskForINFOTECH.Models
{
    public class Owner
    {
        public Owner()
        {
            CarOwners = new List<CarOwner>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string IdentificationNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public List<CarOwner> CarOwners { get; set; }

    }
}
