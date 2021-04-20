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

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _repository.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int customerPage = 1)
        {
            IQueryable<Customer> allCustomers = _repository.GetAllCustomers();
            IQueryable<Customer> someCustomers = allCustomers.OrderBy(p => p.CustomerId).Skip((customerPage - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allCustomers.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = customerPage;

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

        public IActionResult SearchCustomer(string keyword)
        {
            IQueryable<Customer> customer = _repository.GetCustomersByKeyword(keyword);
            return View(customer);
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            Customer customer = _repository.GetCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            Customer updatedCustomer = _repository.UpdateCustomer(customer);
            return RedirectToAction("CustomerDetail", new { id = customer.CustomerId });
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
            _repository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
