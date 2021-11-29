using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public interface IRentRepository
    {
        public bool AddRentDetail(RentDetail rentDetail);
        public bool DeleteFromRent(RentDetail rentDetail);
        public bool DeleteAllRentDetails();
        public Rent GetRent();
        public List<RentDetail> GetRentDetails();
    }
}
