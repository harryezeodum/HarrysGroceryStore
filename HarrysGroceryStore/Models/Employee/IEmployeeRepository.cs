using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IEmployeeRepository
    {
        public Employee AddEmployee(Employee employee);

        public IQueryable<Employee> GetAllEmployees();

        public Employee GetEmployeeById(int employeeId);

        public IQueryable<Employee> GetEmployeesByKeyword(string keyword);

        public Employee UpdateEmployee(Employee employee);

        public bool DeleteEmployee(int id);
    }
}
