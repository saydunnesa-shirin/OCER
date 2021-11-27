using OCER.Common.Models;
using System;
using System.Collections.Generic;

namespace OCER.Repository
{
    public class RentRepository : IRentRepository
    {
        public bool AddToRent(RentDetail rentDetail)
        {
            var rent = new Rent { Id = 1, 
                CustomerId = MockData.AllCustomers.Find(q=>q.Id == 1).Id, 
                RentDate = DateTime.UtcNow };

            rentDetail.Id = MockData.RentDetails.Count + 1;
            rentDetail.RentId = rent.Id;

            MockData.RentDetails.Add(rentDetail);

            return true;
        }

        public List<RentDetail> GetRentDetails() => MockData.RentDetails;
    }
}
