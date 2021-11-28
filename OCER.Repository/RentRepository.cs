using OCER.Common.Models;
using System;
using System.Collections.Generic;

namespace OCER.Repository
{
    public class RentRepository : IRentRepository
    {
        public bool AddToRent(RentDetail rentDetail)
        {
            //Save Rent
            MockData.Rent.Id = 1;
            MockData.Rent.CustomerId = MockData.AllCustomers.Find(q => q.Id == MockData.UserId).Id;
            MockData.Rent.RentDate = DateTime.UtcNow;

            //Save Rent Datail
            rentDetail.Id = MockData.RentDetails.Count + 1;
            rentDetail.RentId = MockData.Rent.Id;

            MockData.RentDetails.Add(rentDetail);

            return true;
        }

        public bool DeleteFromRent(RentDetail rentDetail)
        {
            MockData.RentDetails.Remove(rentDetail);
            return true;
        }

        public List<RentDetail> GetRentDetails() => MockData.RentDetails;

        public Rent GetRent()
        {
           MockData.Rent.RentDetails = this.GetRentDetails();
           return MockData.Rent;
        }
    }
}
