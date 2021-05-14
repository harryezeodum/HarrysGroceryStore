using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class OrderDetailController : Controller
    {
        private int _pageSize = 10;
        private IOrderDetailRepository _repository;

        public OrderDetailController(IOrderDetailRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddOrderDetail(int orderId, int employeeId, int customerId)
        {
            OrderDetail od = new OrderDetail();
            od.OrderId = orderId;

            return View(od);
        }

        [HttpPost]
        public IActionResult AddOrderDetail(OrderDetail od)
        {
            _repository.AddOrderDetail(od);
            return RedirectToAction("OrderDetail", "Order", new { id = od.OrderId });
        }

        public IActionResult Index(int page = 1)
        {
            IQueryable<OrderDetail> allOrderDetails = _repository.GetAllOrderDetails();
            IQueryable<OrderDetail> someOrderDetails = allOrderDetails.OrderBy(p => p.OrderDetailId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allOrderDetails.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            lvm.PagingInformation = pi;

            lvm.OrderDetails = someOrderDetails;

            return View(lvm);
        }

        public IActionResult OrderDetail(int id)
        {
            OrderDetail orderDetail = _repository.GetOrderDetailById(id);
            if (orderDetail != null)
            {
                return View(orderDetail);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateOrderDetail(int id)
        {
            OrderDetail orderDetail = _repository.GetOrderDetailById(id);
            if (orderDetail != null)
            {
                return View(orderDetail);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetail updatedOrderDetail = _repository.UpdateOrderDetail(orderDetail);
            return RedirectToAction("OrderDetail", new { id = orderDetail.OrderDetailId });
        }

        [HttpGet]
        public IActionResult DeleteOrderDetail(int id)
        {
            OrderDetail orderDetail = _repository.GetOrderDetailById(id);
            if (orderDetail != null)
            {
                return View(orderDetail);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteOrderDetail(OrderDetail orderDetail, int id)
        {
            _repository.DeleteOrderDetail(id);
            return RedirectToAction("Index");
        }
    }
}
