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

        public IEnumerable<Equipment> AllEquipments(bool? InStock = null)
        {
            _logger.LogInformation("Getting all equipments");
           return _equipmentRepository.AllEquipments(InStock);
        }

        public Equipment GetEquipmentById(int id) => _equipmentRepository.GetEquipmentById(id);

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType) => _equipmentRepository.GetEquipmentsByType(equipmentType);

        public void StockOutEquipment(int id)
        {
            _equipmentRepository.StockOutEquipment(id);
        }

        public void StockInEquipment(int id)
        {
            _equipmentRepository.StockInEquipment(id);
        }
    }
}
