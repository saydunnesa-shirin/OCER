using OCER.Common.Models;
using System.Collections.Generic;

namespace OCER.Service
{
    public interface ICustomerService
    {
        public Customer GetCustomerById(int id);

        public List<Customer> AllCustomers();


    }
}
