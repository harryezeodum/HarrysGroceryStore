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

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            _repository.CreateUser(user);
            return RedirectToAction("Main");
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _repository.CreateUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int userPage = 1)
        {
            IQueryable<User> allUsers = _repository.GetAllUsers();
            IQueryable<User> someUsers = allUsers.OrderBy(u => u.UserId).Skip((userPage - 1) * _pageSize).Take(_pageSize);
            ViewBag.userCount = allUsers.Count();

            return View(someUsers);
        }

        public IActionResult Details(int id)
        {
            User u = _repository.GetUserById(id);
            if (u != null)
            {
                return View(u);
            }
            return RedirectToAction("Index");
        }

        //public ViewResult ProfileDetails()
        //{
        //
        //}
        //
        //[HttpGet]
        //public IActionResult EditProfile(string firstName)
        //{
        //
        //}
        //
        //[HttpPost]
        //public IActionResult EditProfile(User edit)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    if (edit.PassWord == edit.ConfirmPassword)
        //    //    {
        //    //        return RedirectToAction("ProfileDetails", edit); ;
        //    //    }
        //    //    ModelState.AddModelError("", "Password don't match");
        //    //}
        //    return View(edit);
        //}

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Search(string keyword)
        {
            IQueryable<User> u = _repository.GetUsersByKeyword(keyword);
            return View(u);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            User u = _repository.GetUserById(id);
            if (u != null)
            {
                return View(u);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(User u)
        {
            User updatedProduct = _repository.UpdateUser(u);
            return RedirectToAction("Details", new { id = u.UserId });
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            User u = _repository.GetUserById(id);
            if (u != null)
            {
                return View(u);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(User u, int id)
        {
            _repository.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
