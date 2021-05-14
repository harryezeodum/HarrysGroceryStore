using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class OrderController : Controller
    {
        private int _pageSize = 10;
        private IOrderRepository _repository;
        private IUserRepository _userRepository;

        public OrderController(IOrderRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult AddOrder(int orderId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                int userId = _userRepository.GetLoggedInUserId();
                User u = _userRepository.GetUserById(userId);
                order.CustomerId = u.CustomerId;
                _repository.AddOrder(order);
                return RedirectToAction("Index", "Order", new { id = order.OrderId });
            }

            return RedirectToAction("Index", "Order");

        }

        [HttpGet]
        public IActionResult AddAdminOrder(int orderId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdminOrder(Order order)
        {
            _repository.AddOrder(order);
            return RedirectToAction("OrderIndex", "Order", new { id = order.OrderId });

        }

        public IActionResult Index(int page = 1)
        {
            IQueryable<Order> allOrders = _repository.GetAllOrders();
            IQueryable<Order> someOrders = allOrders.OrderBy(p => p.OrderId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allOrders.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            lvm.PagingInformation = pi;

            lvm.Orders = someOrders;

            return View(lvm);
        }

        public IActionResult OrderIndex(int page = 1)
        {
            IQueryable<Order> allOrders = _repository.GetAllAdminOrders();
            IQueryable<Order> someOrders = allOrders.OrderBy(p => p.OrderId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allOrders.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            lvm.PagingInformation = pi;

            lvm.Orders = someOrders;

            return View(lvm);
        }

        public IActionResult OrderDetail(int id)
        {
            Order order = _repository.GetOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AdminOrderDetail(int id)
        {
            Order order = _repository.GetAdminOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("OrderIndex");
        }

        [HttpGet]
        public IActionResult UpdateAdminOrder(int id)
        {
            Order order = _repository.GetAdminOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("OrderIndex");
        }

        [HttpPost]
        public IActionResult UpdateAdminOrder(Order order)
        {
            Order updatedOrder = _repository.UpdateOrder(order);
            return RedirectToAction("AdminOrderDetail", new { id = order.OrderId });
        }

        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            Order order = _repository.GetOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            Order updatedOrder = _repository.UpdateOrder(order);
            return RedirectToAction("OrderDetail", new { id = order.OrderId });
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            Order order = _repository.GetOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteOrder(Order order, int id)
        {
            _repository.DeleteOrder(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAdminOrder(int id)
        {
            Order order = _repository.GetAdminOrderById(id);
            if (order != null)
            {
                return View(order);
            }
            return RedirectToAction("OrderIndex");
        }

        [HttpPost]
        public IActionResult DeleteAdminOrder(Order order, int id)
        {
            _repository.DeleteOrder(id);
            return RedirectToAction("OrderIndex");
        }
    }
}
