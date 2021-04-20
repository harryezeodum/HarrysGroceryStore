using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface ISalesOrderRepository
    {
        public SalesOrder AddSalesOrder(SalesOrder salesOrder);

        public IQueryable<SalesOrder> GetAllSalesOrders();

        public SalesOrder GetSalesOrderById(int orderId);

        public SalesOrder UpdateSalesOrder(SalesOrder salesOrder);

        public bool DeleteSalesOrder(int id);
    }
}
