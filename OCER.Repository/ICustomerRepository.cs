using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Repository
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);

        public List<Customer> AllCustomers();
    }
}
