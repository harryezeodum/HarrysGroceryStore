using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IEmployeeRepository
    {
        public Employee Create(Employee employee);

        public IQueryable<Employee> GetAllEmployees();

        public IQueryable<Employee> GetAllAdminEmployees();

        public Employee GetEmployeeById(int employeeId);

        public Employee GetAdminEmployeeById(int employeeId);

        public IQueryable<Employee> GetEmployeesByKeyword(string keyword);

        public Employee Update(Employee employee);

        public bool Delete(int id);
    }
}
