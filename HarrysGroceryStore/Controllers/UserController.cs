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
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User userSignUp)
        {
            if (ModelState.IsValid)
            {
                if (userSignUp.PassWord == userSignUp.ConfirmPassword)
                {
                    Repository.AddResponse(userSignUp);
                    return RedirectToAction("SignOnPage");
                }
                ModelState.AddModelError("", "Password don't match");
            }
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User userLogIn)
        {
            if (ModelState.IsValid)
            {
                if (userLogIn.PassWord == userLogIn.PassWord)
                {
                    Repository.AddResponse(userLogIn);
                    return RedirectToAction("SignOnPage");
                }
                ModelState.AddModelError("", "Password don't match");
            }
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(User adminLogIn)
        {
            if (ModelState.IsValid)
            {
                if (adminLogIn.PassWord == adminLogIn.PassWord)
                {
                    Repository.AddResponse(adminLogIn);
                    return RedirectToAction("");
                }
                ModelState.AddModelError("", "Password don't match");
            }
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

        public IActionResult SignedOn()
        {
            return View();
        }

        public ViewResult ProfileDetails()
        {
            User u = new User();
            u.FirstName = "John";
            u.LastName = "Doe";
            u.Email = "james.michael@aol.com";
            u.PhoneNumber = "713-290-2346";
            u.PassWord = "abcd";
            return View(u);
        }

        [HttpGet]
        public IActionResult EditProfile(string firstName)
        {
            User information = new User();
            information.FirstName = firstName;
            information.LastName = "Smith";
            information.Email = "michael.smith@aol.com";
            information.PhoneNumber = "210-712-2100";
            information.PassWord = "1234";
            information.ConfirmPassword = "1234";
            return View(information);
        }

        [HttpPost]
        public IActionResult EditProfile(User edit)
        {
            if (ModelState.IsValid)
            {
                if (edit.PassWord == edit.ConfirmPassword)
                {
                    Repository.EditResponse(edit);
                    return RedirectToAction("ProfileDetails", edit); ;
                }
                ModelState.AddModelError("", "Password don't match");
            }
            return View(edit);
        }
    }
}
