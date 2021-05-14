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
        private IAdminRepository _adminRepository;

        public EmployeeController(IEmployeeRepository repository, IAdminRepository adminRepository)
        {
            _repository = repository;
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            Employee e = new Employee();
            e.Admin = new Admin();
            return View(e);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _adminRepository.Create(employee.Admin);
            employee.Admin.AdminId = employee.Admin.AdminId;
            employee.Admin = null;
            _repository.Create(employee);

            return RedirectToAction("EmployeeDetail", new { id = employee.EmployeeId });
        }

        public IActionResult Index(int page = 1)
        {
            IQueryable<Employee> allEmployees = _repository.GetAllEmployees();
            IQueryable<Employee> someEmployees = allEmployees.OrderBy(p => p.EmployeeId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allEmployees.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            lvm.PagingInformation = pi;

            lvm.Employees = someEmployees;

            return View(lvm);
        }

        public IActionResult EmployeeIndex(int page = 1)
        {
            IQueryable<Employee> allEmployees = _repository.GetAllAdminEmployees();
            IQueryable<Employee> someEmployees = allEmployees.OrderBy(p => p.EmployeeId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allEmployees.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

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

        public IActionResult AdminEmployeeDetail(int id)
        {
            Employee employee = _repository.GetAdminEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("EmployeeIndex");
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
            Employee updatedEmployee = _repository.Update(employee);
            return RedirectToAction("EmployeeDetail", new { id = employee.EmployeeId });
        }

        [HttpGet]
        public IActionResult UpdateAdminEmployee(int id)
        {
            Employee employee = _repository.GetAdminEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("EmployeeIndex");
        }

        [HttpPost]
        public IActionResult UpdateAdminEmployee(Employee employee)
        {
            Employee updatedEmployee = _repository.Update(employee);
            return RedirectToAction("AdminEmployeeDetail", "Employee", new { id = employee.EmployeeId });
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
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAdminEmployee(int id)
        {
            Employee employee = _repository.GetAdminEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("AdminIndex");
        }

        [HttpPost]
        public IActionResult DeleteAdminEmployee(Employee employee, int id)
        {
            _repository.Delete(id);
            return RedirectToAction("AdminIndex");
        }
    }
}
