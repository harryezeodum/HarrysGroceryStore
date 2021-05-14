using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IOrderDetailRepository
    {
        public OrderDetail AddOrderDetail(OrderDetail orderDetail);
        
        public IQueryable<OrderDetail> GetAllOrderDetails();

        public OrderDetail GetOrderDetailById(int orderId);

        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail);

        public bool DeleteOrderDetail(int id);
    }
}
