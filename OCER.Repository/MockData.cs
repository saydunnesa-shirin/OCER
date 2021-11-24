using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public class MockData
    {
        public IEnumerable<Equipment> AllEquipments =>
            new List<Equipment>
            {
                new Equipment{Id=1, Name="Caterpillar bulldozer", InStock=true, EquipmentType = EquipmentType.Heavy},
                new Equipment{Id=2, Name="KamAZ truck", InStock=true, EquipmentType = EquipmentType.Regular},
                new Equipment{Id=3, Name="Komatsu crane", InStock=true, EquipmentType = EquipmentType.Heavy},
                new Equipment{Id=4, Name="Volvo steamroller", InStock=true, EquipmentType = EquipmentType.Regular},
                new Equipment{Id=5, Name="Bosch jackhammer", InStock=true, EquipmentType = EquipmentType.Specialized}
            };
    }
}
