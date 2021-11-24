using System.Collections.Generic;
using OCER.Common.Models;

namespace OCER.Service
{
    public interface IEquipmentService
    {
        public IEnumerable<Equipment> AllEquipments();

        public IEnumerable<Equipment> GetEquipmentsByType(int equipmentType);
    }
}
