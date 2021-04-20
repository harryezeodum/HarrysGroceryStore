using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfCustomerRepository : ICustomerRepository
    {
        private AppDbContext _context;

        public EfCustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer; ;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = _context.Customers.Find(customerId);
            return customer;
        }

        public IQueryable<Customer> GetCustomersByKeyword(string keyword)
        {
            IQueryable<Customer> customers = _context.Customers.Where(p => p.FirstName.Contains(keyword) || p.LastName.Contains(keyword));
            return customers;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            Customer customerToUpdate = _context.Customers.Find(customer.CustomerId);
            if (customerToUpdate != null)
            {
                customerToUpdate.FirstName = customer.FirstName;
                customerToUpdate.LastName = customer.LastName;
                customerToUpdate.PhoneNumber = customer.PhoneNumber;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.City = customer.City;
                customerToUpdate.State = customer.State;
                customerToUpdate.ZipCode = customer.ZipCode;
                _context.SaveChanges();
            }
            return customerToUpdate;
        }

        public bool DeleteCustomer(int id)
        {
            Customer customerToDelete = GetCustomerById(id);
            if (customerToDelete == null)
            {
                return false;
            }
            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
