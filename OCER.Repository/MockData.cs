using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public class MockData
    {
        static MockData()
        {
           AllEquipments =
           new List<Equipment>
            {
                new Equipment{Id=1, Name="Caterpillar bulldozer", InStock=true, EquipmentType = EquipmentType.Heavy},
                new Equipment{Id=2, Name="KamAZ truck", InStock=true, EquipmentType = EquipmentType.Regular},
                new Equipment{Id=3, Name="Komatsu crane", InStock=true, EquipmentType = EquipmentType.Heavy},
                new Equipment{Id=4, Name="Volvo steamroller", InStock=true, EquipmentType = EquipmentType.Regular},
                new Equipment{Id=5, Name="Bosch jackhammer", InStock=true, EquipmentType = EquipmentType.Specialized}
            };

            AllCustomers =
            new List<Customer>
            {
                new Customer{Id=1, Name="Saydunnesa Shirin", Email="saydunnesa.shirin@gmail.com"},
                new Customer{Id=2, Name="Lisa K.", Email="lisa.k@gmail.com"}
            };

            Rent = new Rent();
            RentDetails = new List<RentDetail>();
        }
        public static int UserId = 2;
        public static IEnumerable<Equipment> AllEquipments;
        public static List<Customer> AllCustomers;

        public static Rent Rent;
        public static List<RentDetail> RentDetails;

    }
}
