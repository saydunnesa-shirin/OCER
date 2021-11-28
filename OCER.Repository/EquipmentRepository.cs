using OCER.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace OCER.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public IEnumerable<Equipment> AllEquipments(bool? InStock = null)
        {
            if(InStock != null)
                return MockData.AllEquipments.Where(q => q.InStock == true);
            return MockData.AllEquipments;
        }

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType = 0) => MockData.AllEquipments
                .Where(q => q.InStock == true && (int)q.EquipmentType == equipmentType);
        
        public Equipment GetEquipmentById(int equipmentId) => MockData.AllEquipments.FirstOrDefault(q => q.Id == equipmentId && q.InStock == true);

        public void StockOutEquipment(int id)
        {
            MockData.AllEquipments.Where(x => x.Id == id).First().InStock =  false;
        }

        public void StockInEquipment(int id)
        {
            MockData.AllEquipments.Where(x => x.Id == id).First().InStock = true;
        }
    }
}
