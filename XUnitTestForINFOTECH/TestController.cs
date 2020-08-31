using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskForINFOTECH.Controllers;
using TestTaskForINFOTECH.Models;
using TestTaskForINFOTECH.Services;
using Xunit;

namespace XUnitTestForINFOTECH
{
    public class TestController
    {
        [Fact]
        public async Task ReturnsAllOwners_WithCorrectCarNumber()
        {
            // Arrange
            string carNumber = "AA0000AA";
            var mock = new Mock<CarOwnerRepository>();
            mock.Setup(r => r.OwnersByCar(carNumber)).Returns(GetListOwner());
            var controller = new CarOwnerController(mock.Object);

            // Act
            var result = controller.OwnersByCar(carNumber);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<JsonResult>(result);
            Assert.Equal(result.ToString(), new JsonResult(GetListOwner()).ToString());
        }

        [Fact]
        public async Task ReturnesAllCarsByOwner_WithCorrectOwner()
        {
            // Arrange
            
            var mock = new Mock<CarOwnerRepository>();
            mock.Setup(r => r.CarsByOwner(testOwner())).Returns(GetListCars());
            var controller = new CarOwnerController(mock.Object);

            // Act
            var result = controller.CarsByOwner(testOwner());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<JsonResult>(result);
            Assert.Equal(result.ToString(), new JsonResult(GetListCars()).ToString());
        }
        private Owner testOwner ()
        {
            return CarOwnerContext.GetOwners[0];
        }
        private List<Owner> GetListOwner ()
        {
            return new List<Owner> 
            {
               CarOwnerContext.GetOwners[0],
               CarOwnerContext.GetOwners[1],
               CarOwnerContext.GetOwners[2]
            };
        }
        private List<Car> GetListCars()
        {
            return new List<Car> 
            {
                CarOwnerContext.GetCars[0],
                CarOwnerContext.GetCars[1],
                CarOwnerContext.GetCars[2],
                CarOwnerContext.GetCars[3]
            };
        }
    }
}
