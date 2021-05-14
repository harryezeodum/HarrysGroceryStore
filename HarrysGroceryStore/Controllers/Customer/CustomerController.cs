using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class CustomerController : Controller
    {
        private int _pageSize = 10;
        private ICustomerRepository _repository;
        private IUserRepository _userRepository;

        public CustomerController(ICustomerRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            Customer c = new Customer();
            c.User = new User();
            return View(c);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _userRepository.Create(customer.User);
            customer.User.UserId = customer.User.UserId;
            customer.User = null;
            _repository.Create(customer);

            return RedirectToAction("CustomerDetail", new { id = customer.CustomerId });
        }

        public IActionResult CustomerIndex(int page = 1)
        {
            IQueryable<Customer> allCustomers = _repository.GetAllAdminCustomers();
            IQueryable<Customer> someCustomers = allCustomers.OrderBy(p => p.CustomerId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allCustomers.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            lvm.PagingInformation = pi;

            lvm.Customers = someCustomers;

            return View(lvm);
        }

        public IActionResult Index(int page = 1)
        {
            IQueryable<Customer> allCustomers = _repository.GetAllCustomers();
            IQueryable<Customer> someCustomers = allCustomers.OrderBy(p => p.CustomerId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allCustomers.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            lvm.PagingInformation = pi;

            lvm.Customers = someCustomers;

            return View(lvm);
        }

        public IActionResult CustomerDetail(int id)
        {
            Customer customer = _repository.GetCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AdminCustomerDetail(int id)
        {
            Customer customer = _repository.GetAdminCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("CustomerIndex");
        }

        public IActionResult SearchCustomer(string keyword)
        {
            IQueryable<Customer> customer = _repository.GetCustomersByKeyword(keyword);
            return View(customer);
        }

        [HttpGet]
        public IActionResult UpdateAdminCustomer(int id)
        {
            Customer customer = _repository.GetAdminCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("AdminCustomerDetail", "Customer", new { id = customer.CustomerId });
        }

        [HttpPost]
        public IActionResult UpdateAdminCustomer(Customer customer)
        {
            Customer updatedCustomer = _repository.Update(customer);
            return RedirectToAction("AdminCustomerDetail", "Customer", new { id = customer.CustomerId });
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id, User u)
        {
            Customer customer = _repository.GetCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("UserDetail", "User", new { id = u.UserId });
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            Customer updatedCustomer = _repository.Update(customer);
            return RedirectToAction("UserDetail", "User", new { id = customer.CustomerId });
        }

        [HttpGet]
        public IActionResult DeleteAdminCustomer(int id)
        {
            Customer customer = _repository.GetAdminCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("CustomerIndex");
        }

        [HttpPost]
        public IActionResult DeleteAdminCustomer(Customer customer, int id)
        {
            _repository.Delete(id);
            return RedirectToAction("CustomerIndex");
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = _repository.GetCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCustomer(Customer customer, int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
