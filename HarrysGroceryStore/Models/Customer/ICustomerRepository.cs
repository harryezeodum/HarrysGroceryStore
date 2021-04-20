using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface ICustomerRepository
    {
        public Customer AddCustomer(Customer customer);

        public IQueryable<Customer> GetAllCustomers();

        public Customer GetCustomerById(int customerId);

        public IQueryable<Customer> GetCustomersByKeyword(string keyword);

        public Customer UpdateCustomer(Customer id);

        public bool DeleteCustomer(int id);
    }
}
