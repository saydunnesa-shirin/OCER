using Microsoft.Extensions.Logging;
using OCER.Common.Models;
using OCER.Repository;
using System.Collections.Generic;

namespace OCER.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository )
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        public Customer GetCustomerById(int id) => _customerRepository.GetCustomerById(id);

        public List<Customer> AllCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}
