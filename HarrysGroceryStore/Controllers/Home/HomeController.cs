using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _repository;

        public HomeController(IUserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult WelcomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            _repository.AddUser(user);
            return RedirectToAction("Main");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User userLogIn)
        {
            //if (ModelState.IsValid)
            //{
            //    if (userLogIn.PassWord == userLogIn.PassWord)
            //    {
            //        return RedirectToAction("SignOnPage");
            //    }
            //    ModelState.AddModelError("", "Password don't match");
            //}
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(User adminLogIn)
        {
            //if (ModelState.IsValid)
            //{
            //    if (adminLogIn.PassWord == adminLogIn.PassWord)
            //    {
            //        return RedirectToAction("");
            //    }
            //    ModelState.AddModelError("", "Password don't match");
            //}
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }

        public ViewResult ProfileDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile(string firstName)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProfile(User edit)
        {
            //if (ModelState.IsValid)
            //{
            //    if (edit.PassWord == edit.ConfirmPassword)
            //    {
            //        return RedirectToAction("ProfileDetails", edit); ;
            //    }
            //    ModelState.AddModelError("", "Password don't match");
            //}
            //turn View(edit);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(User reset)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
