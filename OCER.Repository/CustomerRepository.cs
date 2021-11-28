using OCER.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace OCER.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerById(int id) => MockData.AllCustomers.FirstOrDefault(q => q.Id == id);

        public List<Customer> AllCustomers() => MockData.AllCustomers;
    }
}
