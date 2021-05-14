using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IOrderRepository
    {
        public Order AddOrder(Order order);

        public IQueryable<Order> GetAllOrders();

        public IQueryable<Order> GetAllAdminOrders();

        public Order GetOrderById(int orderId);

        public Order GetAdminOrderById(int orderId);

        public Order UpdateOrder(Order order);

        public bool DeleteOrder(int id);
    }
}
