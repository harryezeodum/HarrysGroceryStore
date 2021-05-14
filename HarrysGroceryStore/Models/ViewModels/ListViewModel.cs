using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class ListViewModel
    {
        public IQueryable<Admin> Admins { get; set; }

        public IQueryable<User> Users { get; set; }

        public IQueryable<Product> Products { get; set; }

        public IQueryable<Customer> Customers { get; set; }

        public IQueryable<Employee> Employees { get; set; }

        public IQueryable<Order> Orders { get; set; }

        public IQueryable<OrderDetail> OrderDetails { get; set; }

        public IQueryable<Supplier> Suppliers { get; set; }

        public PagingInfo PagingInformation { get; set; }

        public string CurrentCategory { get; set; }
    }
}
