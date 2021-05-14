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
        private ICustomerRepository _customerRepository;
        private IEmailRepository _emailRepository;

        public UserController(IUserRepository repository, ICustomerRepository customerRepository, IEmailRepository emailRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _emailRepository = emailRepository;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            User u = new User();
            u.Customer = new Customer();
            return View(u);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _customerRepository.Create(user.Customer);
            user.CustomerId = user.Customer.CustomerId;
            user.Customer = null;
            _repository.Create(user);

            return RedirectToAction("UserDetail", new { id = user.UserId });
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserRegistrationViewModel user)
        {
            if (ModelState.IsValid)
            {
                Customer c = new Customer();
                c.FirstName = user.FirstName;
                c.LastName = user.LastName;
                _customerRepository.Create(c);
                User u = new User();
                u.PassWord = user.Password;
                u.Email = user.EmailAddress;
                u.CustomerId = c.CustomerId;
                User newUser = _repository.Create(u);
                if (newUser == null)
                {
                    ModelState.AddModelError("", "User Already Exists");
                    return View(user);
                }
            }
            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User u)
        {
          bool loggedIn = _repository.Login(u);
            if (loggedIn == true)
            {
                return RedirectToAction("Main", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect Password");
            }
            return View(u); 
        }

        public IActionResult Logout()
        {
            _repository.Logout();
            return RedirectToAction("Welcomepage", "Home");
        }

        public IActionResult Index(int page = 1)
        {
            IQueryable<User> allUsers = _repository.GetAllUsers();
            IQueryable<User> someUsers = allUsers.OrderBy(u => u.UserId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel user = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allUsers.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

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
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(UserChangePasswordViewModel ucpvm)
        {
            if (ModelState.IsValid)
            {
                bool success = _repository.ChangePassword(ucpvm.CurrentPassword, ucpvm.NewPassword);
                if (success == true)
                {
                    return RedirectToAction("UserDetail");
                }
                ModelState.AddModelError("", "Old password is incorrect");
            }
            return View(ucpvm);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult ResetPassword(string emailAddress)
        {
            string newPassword = _repository.ResetPassword(emailAddress);
            if (newPassword != null)
            {
                //send an email
                _emailRepository.SendEmail(emailAddress, "Reset Password", "Here is your new password" + newPassword);
            }

            return RedirectToAction("LogIn", "User");
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
            User updatedUser = _repository.Update(user);
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
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
