using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public interface IEquipmentRepository
    {
        public IEnumerable<Equipment> AllEquipments(bool? InStock = null);

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType);

        Equipment GetEquipmentById(int equipmentId);

        public void StockOutEquipment(int id);

        public void StockInEquipment(int id);
    }
}
