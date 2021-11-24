using Microsoft.Extensions.Logging;
using OCER.Common.Models;
using OCER.Repository;
using System.Collections.Generic;

namespace OCER.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ILogger<EquipmentService> _logger;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(ILogger<EquipmentService> logger, IEquipmentRepository equipmentRepository )
        {
            _logger = logger;
            _equipmentRepository = equipmentRepository;
        }

        public IEnumerable<Equipment> AllEquipments()
        {
            _logger.LogInformation("Getting all equipments");
           return _equipmentRepository.AllEquipments();
        }

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType) => _equipmentRepository.GetEquipmentsByType(equipmentType);
    }
}
