using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskForINFOTECH.Services;

namespace TestTaskForINFOTECH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarOwnerController : Controller
    {
        private CarOwnerRepository repository;
        public CarOwnerController(CarOwnerRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Cars ()
        {
            return Json(repository.GetAllCars());
        }
        [HttpGet("{carNumber}")]
        public IActionResult OwnersByCar(string carNumber)
        {
            return Json(repository.OwnersByCar(carNumber));
        }
    }
}
