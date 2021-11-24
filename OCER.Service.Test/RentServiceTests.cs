using NUnit.Framework;
using OCER.Service;
using OCER.Repository;
using Moq;
using Microsoft.Extensions.Logging;
using System.Linq;
using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Service.Test
{
    public class RentServiceTests
    {
        private readonly IRentService _rentService;
        public RentServiceTests()
        {
            var rentServiceLogger = new Mock<ILogger<RentService>>();
            _rentService = new RentService(rentServiceLogger.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatePriceByEquipmentTypeZeroAndNoOfDaysZero_Test()
        {
            //Arrange
            var equipmentType = 0; var noOfDays = 0;

            //Act
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(0,result);
        }

        [Test]
        public void CalculatePrice_ReturnsZero_WhenUnknownEquipmentType()
        {
            //Arrange
            var equipmentType = 5; var noOfDays = 5;

            //Act
            
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalculatePrice_ReturnCurrectPrice_ForEquipmentTypeHavey()
        {
            //Arrange
            var equipmentType = (int)EquipmentType.Heavy; var noOfDays = 5;

            //Act
            var actual = (int)FeeType.OneTime + (int)FeeType.Premium * noOfDays;
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(actual, result);
        }

        public void CalculatePrice_ReturnCurrectPrice_ForEquipmentTypeRegular()
        {
            //Arrange
            var equipmentType = (int)EquipmentType.Regular; var noOfDays = 5;

            //Act
            var actual = (int)FeeType.OneTime + (int)FeeType.Premium * noOfDays;
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(actual, result);
        }

        public void CalculatePrice_ReturnCurrectPrice_ForEquipmentTypeSpecialized()
        {
            //Arrange
            var equipmentType = (int)EquipmentType.Specialized; var noOfDays = 5;

            //Act
            var actual = (int)FeeType.OneTime + (int)FeeType.Premium * noOfDays;
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(actual, result);
        }

    }
}