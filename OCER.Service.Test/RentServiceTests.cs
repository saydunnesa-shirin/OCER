using NUnit.Framework;
using OCER.Repository;
using Moq;
using Microsoft.Extensions.Logging;
using OCER.Common.Models;

namespace OCER.Service.Test
{
    public class RentServiceTests
    {
        private readonly IRentService _rentService;
        private readonly Mock<IRentRepository> _mockRentRepository;
        public RentServiceTests()
        {
            var rentServiceLogger = new Mock<ILogger<RentService>>();
            _mockRentRepository = new Mock<IRentRepository>();
            _rentService = new RentService(rentServiceLogger.Object, _mockRentRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatePriceByEquipmentTypeZeroAndNoOfDaysZero()
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

        [Test]
        public void CalculatePrice_ReturnCurrectPrice_ForEquipmentTypeRegular()
        {
            //Arrange
            var equipmentType = (int)EquipmentType.Regular; var noOfDays = 5;

            //Act
            var actual = (int)FeeType.OneTime + (int)FeeType.Premium * 2 + (int)FeeType.Regular * (noOfDays - 2);
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(actual, result);
        }

        [Test]
        public void CalculatePrice_ReturnCurrectPrice_ForEquipmentTypeSpecialized()
        {
            //Arrange
            var equipmentType = (int)EquipmentType.Specialized; var noOfDays = 5;

            //Act
            var actual = (int)FeeType.Premium * 3 + (int)FeeType.Regular * (noOfDays - 3);
            var result = _rentService.CalculatePrice(equipmentType, noOfDays);
            //Assert

            Assert.AreEqual(actual, result);
        }

        [Test]
        public void CalculateBonusByTypeZero()
        {
            //Arrange
            var equipmentType = 0;

            //Act
            var result = _rentService.CalculateBonus(equipmentType);
            //Assert

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalculateBonus_ReturnCurrectBonus_ForEquipmentTypeHavey()
        {
            //Arrange
            var equipmentType = EquipmentType.Heavy;

            //Act
            var result = _rentService.CalculateBonus((int)equipmentType);
            //Assert

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CalculateBonus_ReturnCurrectBonus_ForEquipmentTypeRegular()
        {
            //Arrange
            var equipmentType = EquipmentType.Regular;

            //Act
            var result = _rentService.CalculateBonus((int)equipmentType);
            //Assert

            Assert.AreEqual(1, result);
        }

        [Test]
        public void CalculateBonus_ReturnCurrectBonus_ForEquipmentTypeSpecialized()
        {
            //Arrange
            var equipmentType = EquipmentType.Specialized;

            //Act
            var result = _rentService.CalculateBonus((int)equipmentType);
            //Assert

            Assert.AreEqual(1, result);
        }
    }
}