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
            return new Owner
            {
                FirstName = "Alex",
                LastName = "Alexeenko",
                Surname = "Alexeevich",
                Id = 1,
                IdentificationNumber = "0987654321",
                DateOfBirth = new DateTime(1990, 1, 1)
            };
        }
        private List<Owner> GetListOwner ()
        {
            return new List<Owner> { testOwner(),                 
                new Owner
                {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Surname = "Ivanovich",
                Id = 2,
                IdentificationNumber = "1234567890",
                DateOfBirth = new DateTime(1995,4,4)
                }
            };
        }
        private List<Car> GetListCars()
        {
            return new List<Car> { 
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
            };
        }
    }
}
