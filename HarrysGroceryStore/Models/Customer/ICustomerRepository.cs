using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface ICustomerRepository
    {
        public Customer Create(Customer customer);

        public IQueryable<Customer> GetAllAdminCustomers();

        public IQueryable<Customer> GetAllCustomers();

        public Customer GetAdminCustomerById(int customerId);

        public Customer GetCustomerById(int customerId);

        public IQueryable<Customer> GetCustomersByKeyword(string keyword);

        public Customer Update(Customer id);

        public bool Delete(int id);
    }
}
