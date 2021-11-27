using System.Collections.Generic;
using OCER.Common.Models;

namespace OCER.Service
{
    public interface IEquipmentService
    {
        public IEnumerable<Equipment> AllEquipments(bool? InStock = null);

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType);

        public Equipment GetEquipmentById(int id);

        public void StockOutEquipment(int id);
    }
}
