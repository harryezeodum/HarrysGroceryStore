using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        private AppDbContext _context;
        private IUserRepository _userRepository;

        public EfOrderRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public IQueryable<Order> GetAllAdminOrders()
        {
            return _context.Orders;
        }

        public IQueryable<Order> GetAllOrders()
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Orders.Include(o => o.Customer).Include(o => o.OrderDetails).ThenInclude(o => o.Product).Where(o => o.Customer.User.UserId == _userRepository.GetLoggedInUserId());
            }
            Order[] noOrder = new Order[0];
            return noOrder.AsQueryable<Order>();
        }

        public Order GetOrderById(int orderId)
        {
            Order order = _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product).Include(o => o.Employee).Include(o => o.Customer).Where(o => o.OrderId == orderId).FirstOrDefault();
            return order;
        }

        public Order GetAdminOrderById(int orderId)
        {
            Order order = _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product).Include(o => o.Employee).Include(o => o.Customer).Where(o => o.OrderId == orderId).FirstOrDefault();
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            Order orderToUpdate = _context.Orders.Find(order.OrderId);
            if (orderToUpdate != null)
            {
                orderToUpdate.SalesAmount = order.SalesAmount;
                orderToUpdate.OrderDate = order.OrderDate;
                orderToUpdate.ShippedDate = order.ShippedDate;
                orderToUpdate.ShipAddress = order.ShipAddress;
                orderToUpdate.ShipCity = order.ShipCity;
                orderToUpdate.State = order.State;
                orderToUpdate.Zipcode = order.Zipcode;
                _context.SaveChanges();
            }
            return orderToUpdate;
        }

        public bool DeleteOrder(int id)
        {
            Order orderToDelete = GetOrderById(id);
            if (orderToDelete == null)
            {
                return false;
            }
            _context.Orders.Remove(orderToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
