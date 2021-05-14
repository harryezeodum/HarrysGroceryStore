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

        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(User adminLogIn)
        {
            return View();
        }

        public IActionResult AdminMain()
        {
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
