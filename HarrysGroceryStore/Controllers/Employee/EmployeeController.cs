using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class EmployeeController : Controller
    {
        private int _pageSize = 10;
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _repository.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int employeePage = 1)
        {
            IQueryable<Employee> allEmployees = _repository.GetAllEmployees();
            IQueryable<Employee> someEmployees = allEmployees.OrderBy(p => p.EmployeeId).Skip((employeePage - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allEmployees.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = employeePage;

            lvm.PagingInformation = pi;

            lvm.Employees = someEmployees;

            return View(lvm);
        }

        public IActionResult EmployeeDetail(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchEmployee(string keyword)
        {
            IQueryable<Employee> employees = _repository.GetEmployeesByKeyword(keyword);
            return View(employees);
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            Employee updatedEmployee = _repository.UpdateEmployee(employee);
            return RedirectToAction("EmployeeDetail", new { id = employee.EmployeeId });
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee, int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
