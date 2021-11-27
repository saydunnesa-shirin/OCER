using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public interface IRentRepository
    {
        public bool AddToRent(RentDetail rentDetail);

        public List<RentDetail> GetRentDetails();
    }
}
