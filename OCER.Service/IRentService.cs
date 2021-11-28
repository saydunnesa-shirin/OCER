using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Service
{
    public interface IRentService
    {
        public bool AddToRent(RentDetail rentDetail);
        public bool DeleteFromRent(RentDetail rentDetail);
        public List<RentDetail> GetRentDetails();
        public Rent GetRent();
        public decimal CalculatePrice(int equipmentType, int noOfDays);
        public int CalculateBonus(int equipmentType);
    }
}
