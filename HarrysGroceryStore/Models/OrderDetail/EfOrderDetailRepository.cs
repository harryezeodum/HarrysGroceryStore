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

        public IQueryable<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails;
        }

        public OrderDetail GetOrderDetailById(int orderId)
        {
            OrderDetail orderDetail = _context.OrderDetails.Find(orderId);
            return orderDetail;
        }

        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetail OrderDetailToUpdate = _context.OrderDetails.Find(orderDetail.OrderId);
            if (OrderDetailToUpdate != null)
            {
                OrderDetailToUpdate.UnitPrice = orderDetail.UnitPrice;
                OrderDetailToUpdate.Quantity = orderDetail.Quantity;
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
