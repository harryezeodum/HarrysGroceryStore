using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfOrderDetailRepository : IOrderDetailRepository
    {
        private AppDbContext _context;

        public EfOrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public OrderDetail AddOrderDetail(OrderDetail od)
        {
            _context.OrderDetails.Add(od);
            _context.SaveChanges();
            return od;
        }

        public IQueryable<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails;
        }

        public OrderDetail GetOrderDetailById(int orderDetailId)
        {
            //OrderDetail orderDetail = _context.OrderDetails.Find(orderId);
            OrderDetail orderDetail = _context.OrderDetails.Include(od => od.Order).ThenInclude(od => od.Customer).Include(od => od.Order).ThenInclude(od => od.Employee).Where(od => od.OrderDetailId == orderDetailId).FirstOrDefault();
            return orderDetail;
        }

        public OrderDetail UpdateOrderDetail(OrderDetail od)
        {
            OrderDetail OrderDetailToUpdate = _context.OrderDetails.Find(od.OrderId);
            if (OrderDetailToUpdate != null)
            {
                OrderDetailToUpdate.UnitPrice = od.UnitPrice;
                OrderDetailToUpdate.Quantity = od.Quantity;
                _context.SaveChanges();
            }
            return OrderDetailToUpdate;
        }

        public bool DeleteOrderDetail(int id)
        {
            OrderDetail OrderDetailToDelete = GetOrderDetailById(id);
            if (OrderDetailToDelete == null)
            {
                return false;
            }
            _context.OrderDetails.Remove(OrderDetailToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
