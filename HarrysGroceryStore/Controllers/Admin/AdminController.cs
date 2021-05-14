using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class AdminController : Controller
    {
        private int _pageSize = 10;
        private IAdminRepository _repository;
        private IEmployeeRepository _employeeRepository;
        private IEmailRepository _emailRepository;

        public AdminController(IAdminRepository repository, IEmployeeRepository employeeRepository, IEmailRepository emailRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _emailRepository = emailRepository;
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            Admin a = new Admin();
            a.Employee = new Employee();
            return View(a);
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            _employeeRepository.Create(admin.Employee);
            admin.EmployeeId = admin.Employee.EmployeeId;
            admin.Employee = null;
            _repository.Create(admin);

            return RedirectToAction("AdminDetail", new { id = admin.AdminId });
        }

        [HttpGet]
        public IActionResult AdminSignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSignUp(AdminRegistrationViewModel admin)
        {
            if (ModelState.IsValid)
            {
                Employee e = new Employee();
                e.FirstName = admin.FirstName;
                e.LastName = admin.LastName;
                _employeeRepository.Create(e);
                Admin a = new Admin();
                a.PassWord = admin.Password;
                a.Email = admin.EmailAddress;
                a.EmployeeId = e.EmployeeId;
                Admin newAdmin = _repository.Create(a);
                if (newAdmin == null)
                {
                    ModelState.AddModelError("", "AdminUser Already Exists");
                    return View(admin);
                }
            }
            return RedirectToAction("AdminMain", "Home");
        }

        [HttpGet]
        public IActionResult EmployeePortal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmployeePortal(Admin a)
        {
            bool loggedIn = _repository.EmployeePortal(a);
            if (loggedIn == true)
            {
                return RedirectToAction("AdminMain", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect Password");
            }
            return View(a);
        }

        public IActionResult Logout()
        {
            _repository.Logout();
            return RedirectToAction("Welcomepage", "Home");
        }

        public IActionResult Index(int page = 1)
        {
            IQueryable<Admin> allAdmins = _repository.GetAllAdmins();
            IQueryable<Admin> someAdmins = allAdmins.OrderBy(a => a.AdminId).Skip((page - 1) * _pageSize).Take(_pageSize);

            ListViewModel admin = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allAdmins.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = page;

            admin.PagingInformation = pi;
            admin.Admins = someAdmins;

            return View(admin);
        }

        public IActionResult AdminDetail(int id)
        {
            Admin admin = _repository.GetAdminById(id);
            if (admin != null)
            {
                return View(admin);
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchAdmin(string keyword)
        {
            IQueryable<Admin> admin = _repository.GetAdminByKeyword(keyword);
            return View(admin);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(AdminChangePasswordViewModel acpvm)
        {
            if (ModelState.IsValid)
            {
                bool success = _repository.ChangePassword(acpvm.CurrentPassword, acpvm.NewPassword);
                if (success == true)
                {
                    return RedirectToAction("AdminDetail");
                }
                ModelState.AddModelError("", "Old password is incorrect");
            }
            return View(acpvm);
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

            return RedirectToAction("EmployeePortal", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            Admin admin = _repository.GetAdminById(id);
            if (admin != null)
            {
                return View(admin);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateAdmin(Admin admin)
        {
            Admin updatedAdmin = _repository.Update(admin);
            return RedirectToAction("AdminDetail", new { id = admin.AdminId });
        }

        [HttpGet]
        public IActionResult DeleteAdmin(int id)
        {
            Admin admin = _repository.GetAdminById(id);
            if (admin != null)
            {
                return View(admin);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAdmin(Admin admin, int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
