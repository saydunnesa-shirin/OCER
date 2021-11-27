using NUnit.Framework;
using OCER.Repository;
using Moq;
using Microsoft.Extensions.Logging;
using System.Linq;
using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Service.Test
{
    public class EquipmentServiceTests
    {
        private readonly Mock<IEquipmentRepository> _mockEquipmentRepository;
        private readonly IEquipmentService _equipmentService;
        public EquipmentServiceTests()
        {
            var equipmentServiceLogger = new Mock<ILogger<EquipmentService>>();
            _mockEquipmentRepository = new Mock<IEquipmentRepository>();
            _equipmentService = new EquipmentService(equipmentServiceLogger.Object, _mockEquipmentRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AllEquipments_BasicTest()
        {
            _mockEquipmentRepository.Setup(x => x.AllEquipments(true)).Returns
                (
                    new List<Equipment>
                    {
                        new Equipment{Id=1, Name="Caterpillar bulldozer", InStock=true, EquipmentType = EquipmentType.Heavy}
                    }
                );

            var result = _equipmentService.AllEquipments().ToList();

            Assert.IsTrue(result.Count > 0);

        }

        [Test]
        public void GetEquipmentsByType_BasicTest()
        {
            _mockEquipmentRepository.Setup(x => x.GetEquipmentsByType((int)EquipmentType.Heavy)).Returns
                (
                    new List<Equipment>
                    {
                        new Equipment{Id=1, Name="Caterpillar bulldozer", InStock=true, EquipmentType = EquipmentType.Heavy}
                    }
                );

            var result = _equipmentService.GetEquipmentsByType((int)EquipmentType.Heavy).ToList();

            Assert.AreEqual(1, result.Count);
        }
    }
}