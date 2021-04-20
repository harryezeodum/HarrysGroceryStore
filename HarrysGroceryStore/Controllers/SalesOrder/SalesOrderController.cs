using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class SalesOrderController : Controller
    {
        private int _pageSize = 10;
        private ISalesOrderRepository _repository;

        public SalesOrderController(ISalesOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddSalesOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSalesOrder(SalesOrder salesOrder)
        {
            _repository.AddSalesOrder(salesOrder);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int salesOrderPage = 1)
        {
            IQueryable<SalesOrder> allSalesOrders = _repository.GetAllSalesOrders();
            IQueryable<SalesOrder> someSalesOrders = allSalesOrders.OrderBy(p => p.OrderId).Skip((salesOrderPage - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allSalesOrders.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = salesOrderPage;

            lvm.PagingInformation = pi;

            lvm.SalesOrders = someSalesOrders;

            return View(lvm);
        }

        public IActionResult SalesOrderDetail(int id)
        {
            SalesOrder salesOrder = _repository.GetSalesOrderById(id);
            if (salesOrder != null)
            {
                return View(salesOrder);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSalesOrder(int id)
        {
            SalesOrder salesOrder = _repository.GetSalesOrderById(id);
            if (salesOrder != null)
            {
                return View(salesOrder);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateSalesOrder(SalesOrder salesOrder)
        {
            SalesOrder updatedSalesOrder = _repository.UpdateSalesOrder(salesOrder);
            return RedirectToAction("SalesOrderDetail", new { id = salesOrder.OrderId });
        }

        [HttpGet]
        public IActionResult DeleteSalesOrder(int id)
        {
            SalesOrder salesOrder = _repository.GetSalesOrderById(id);
            if (salesOrder != null)
            {
                return View(salesOrder);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSalesOrder(SalesOrder salesOrder, int id)
        {
            _repository.DeleteSalesOrder(id);
            return RedirectToAction("Index");
        }
    }
}
