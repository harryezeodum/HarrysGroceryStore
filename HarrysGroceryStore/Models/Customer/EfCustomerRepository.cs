using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfCustomerRepository : ICustomerRepository
    {
        private AppDbContext _context;
        private IUserRepository _userRepository;

        public EfCustomerRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Customer Create(Customer customer)
        {
                try
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();                  
                }
                catch (Exception e)
                {

                }
                return customer;
        }

        public IQueryable<Customer> GetAllAdminCustomers()
        {
            return _context.Customers;
        }
        
        public IQueryable<Customer> GetAllCustomers()
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Customers.Where(c => c.CustomerId == _userRepository.GetLoggedInUserId());
            }
            Customer[] NoCustomers = new Customer[0];
            return NoCustomers.AsQueryable<Customer>();
            
        }

        public Customer GetCustomerById(int customerId)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                Customer customer = _context.Customers.Include(customer => customer.Orders).Include(user => user.User).Where(customer => customer.CustomerId == customerId && customer.User.UserId == _userRepository.GetLoggedInUserId()).FirstOrDefault();
                return customer;
            }
            return null;         
        }

        public Customer GetAdminCustomerById(int customerId)
        {
            Customer customer = _context.Customers.Include(customer => customer.Orders).Include(user => user.User).Where(customer => customer.CustomerId == customerId).FirstOrDefault();
            return customer;
        }

        public IQueryable<Customer> GetCustomersByKeyword(string keyword)
        {
            IQueryable<Customer> customers = _context.Customers.Where(p => p.FirstName.Contains(keyword) || p.LastName.Contains(keyword));
            return customers;
        }

        public Customer Update(Customer customer)
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

        public bool Delete(int id)
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
