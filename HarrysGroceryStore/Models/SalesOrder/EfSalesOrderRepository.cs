using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfSalesOrderRepository : ISalesOrderRepository
    {
        private AppDbContext _context;

        public EfSalesOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public SalesOrder AddSalesOrder(SalesOrder salesOrder)
        {
            _context.SalesOrders.Add(salesOrder);
            _context.SaveChanges();
            return salesOrder;
        }

        public IQueryable<SalesOrder> GetAllSalesOrders()
        {
            return _context.SalesOrders;
        }

        public SalesOrder GetSalesOrderById(int orderId)
        {
            SalesOrder salesOrder = _context.SalesOrders.Find(orderId);
            return salesOrder;
        }

        public SalesOrder UpdateSalesOrder(SalesOrder salesOrder)
        {
            SalesOrder salesOrderToUpdate = _context.SalesOrders.Find(salesOrder.OrderId);
            if (salesOrderToUpdate != null)
            {
                salesOrderToUpdate.SalesAmount = salesOrder.SalesAmount;
                salesOrderToUpdate.OrderDate = salesOrder.OrderDate;
                salesOrderToUpdate.ShippedDate = salesOrder.ShippedDate;
                salesOrderToUpdate.ShipAddress = salesOrder.ShipAddress;
                salesOrderToUpdate.ShipCity = salesOrder.ShipCity;
                salesOrderToUpdate.State = salesOrder.State;
                salesOrderToUpdate.Zipcode = salesOrder.Zipcode;
                _context.SaveChanges();
            }
            return salesOrderToUpdate;
        }

        public bool DeleteSalesOrder(int id)
        {
            SalesOrder salesOrderToDelete = GetSalesOrderById(id);
            if (salesOrderToDelete == null)
            {
                return false;
            }
            _context.SalesOrders.Remove(salesOrderToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
