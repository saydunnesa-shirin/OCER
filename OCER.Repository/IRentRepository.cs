using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public interface IRentRepository
    {
        public bool AddToRent(RentDetail rentDetail);

        public bool DeleteFromRent(RentDetail rentDetail);

        public Rent GetRent();
        public List<RentDetail> GetRentDetails();
    }
}
