using OCER.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace OCER.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly MockData _mockData;
        public EquipmentRepository(MockData mockData)
        {
            _mockData = mockData;
        }
        public IEnumerable<Equipment> AllEquipments() => _mockData.AllEquipments.Where(q => q.InStock == true);

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType = 0) => _mockData.AllEquipments
                .Where(q => q.InStock == true && (int)q.EquipmentType == equipmentType);
        //public Equipment GetEquipmentById(int equipmentId) => _mockData.AllEquipments.FirstOrDefault(q => q.Id == equipmentId);
    }
}
