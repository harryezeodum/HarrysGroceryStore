using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class UserController : Controller
    {
        private int _pageSize = 10;
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _repository.AddUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int userPage = 1)
        {
            IQueryable<User> allUsers = _repository.GetAllUsers();
            IQueryable<User> someUsers = allUsers.OrderBy(u => u.UserId).Skip((userPage - 1) * _pageSize).Take(_pageSize);

            ListViewModel user = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allUsers.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = userPage;

            user.PagingInformation = pi;
            user.Users = someUsers;

            return View(user);
        }

        public IActionResult UserDetail(int id)
        {
            User user = _repository.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchUser(string keyword)
        {
            IQueryable<User> user = _repository.GetUsersByKeyword(keyword);
            return View(user);
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            User user = _repository.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            User updatedProduct = _repository.UpdateUser(user);
            return RedirectToAction("UserDetail", new { id = user.UserId });
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            User user = _repository.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(User user, int id)
        {
            _repository.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
