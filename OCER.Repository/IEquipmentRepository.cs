using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public interface IEquipmentRepository
    {
        public IEnumerable<Equipment> AllEquipments();

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType);

        //Equipment GetEquipmentById(int equipmentId);
    }
}
