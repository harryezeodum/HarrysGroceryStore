using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfEmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _context;

        public EfEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee; ;
        } 

        public IQueryable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = _context.Employees.Find(employeeId);
            return employee;
        }

        public IQueryable<Employee> GetEmployeesByKeyword(string keyword)
        {
            IQueryable<Employee> employees = _context.Employees.Where(p => p.FirstName.Contains(keyword) || p.LastName.Contains(keyword));
            return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee employeeToUpdate = _context.Employees.Find(employee.EmployeeId);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.PhoneNumber = employee.PhoneNumber;
                employeeToUpdate.HireDate = employee.HireDate;
                employeeToUpdate.Address = employee.Address;
                employeeToUpdate.City = employee.City;
                employeeToUpdate.State = employee.State;
                employeeToUpdate.ZipCode = employee.ZipCode;
                _context.SaveChanges();
            }
            return employeeToUpdate;
        }

        public bool DeleteEmployee(int id)
        {
            Employee employeeToDelete = GetEmployeeById(id);
            if (employeeToDelete == null)
            {
                return false;
            }
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
