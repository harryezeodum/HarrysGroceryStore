using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfAdminRepository : IAdminRepository
    {
        private AppDbContext _context;
        private ISession _session;

        public EfAdminRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public Admin Create(Admin a)
        {
            Admin existingAdmin = GetAdminByEmailAddress(a.Email);
            if (existingAdmin != null)
            {
                return null;
            }

            _context.Admins.Add(a);
            _context.SaveChanges();
            return a;
        }

        public IQueryable<Admin> GetAllAdmins()
        {
            if (IsAdminLoggedIn())
            {
                return _context.Admins.Include(a => a.Employee).Where(a => a.AdminId == GetLoggedInAdminId());
            }
            Admin[] noAdmin = new Admin[0];
            return noAdmin.AsQueryable<Admin>();
        }

        public Admin GetAdminById(int adminId)
        {
            Admin admin = _context.Admins.Include(a => a.Employee).Where(a => a.AdminId == adminId).FirstOrDefault();
            return admin;
        }

        public IQueryable<Admin> GetAdminByKeyword(string keyword)
        {
            IQueryable<Admin> admins = _context.Admins.Where(a => a.Email.Contains(keyword));
            return admins;
        }

        public Admin GetAdminByEmailAddress(string emailAddress)
        {
            return _context.Admins.Where(a => a.Email == emailAddress).FirstOrDefault();
        }

        public bool EmployeePortal(Admin admin)
        {
            Admin existingAdmin = _context.Admins.FirstOrDefault(a => a.Email == admin.Email && a.PassWord == admin.PassWord);
            if (existingAdmin == null || existingAdmin.PassWord != admin.PassWord)
            {
                return false;
            }
            else
            {
                _session.SetInt32("adminid", existingAdmin.AdminId);
                _session.SetString("email", admin.Email);
                return true;
            }
        }

        public void Logout()
        {
            _session.Remove("adminid");
            _session.Remove("email");
        }

        public bool IsAdminLoggedIn()
        {
            int? adminId = _session.GetInt32("adminid");
            if (adminId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetLoggedInAdminId()
        {
            int? adminId = _session.GetInt32("adminid");
            if (adminId == null)
            {
                return -1;
            }
            else
            {
                return adminId.Value;
            }
        }

        public string GetLoggedInEmail()
        {
            return _session.GetString("email");
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!IsAdminLoggedIn())
            {
                return false;
            }

            Admin adminToUpdate = GetAdminById(GetLoggedInAdminId());

            if (adminToUpdate != null && adminToUpdate.PassWord == oldPassword)
            {
                adminToUpdate.PassWord = newPassword;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string ResetPassword(string emailAddress)
        {
            Admin adminToUpdate = GetAdminByEmailAddress(emailAddress);

            if (adminToUpdate != null)
            {
                adminToUpdate.PassWord = ResetPassword();
                _context.SaveChanges();
                return adminToUpdate.PassWord;
            }
            return null;
        }

        private string ResetPassword()
        {
            Random r = new Random();
            string result = "";
            for (int i = 0; i < 9; i++)
            {
                result = result + (char)r.Next(33, 126);
            }
            return result;
        }

        public Admin Update(Admin a)
        {
            Admin adminToUpdate = _context.Admins.Find(a.AdminId);
            if (adminToUpdate != null)
            {
                adminToUpdate.Email = a.Email;
                adminToUpdate.PassWord = a.PassWord;
                _context.SaveChanges();
            }
            return adminToUpdate;
        }

        public bool Delete(int id)
        {
            Admin adminToDelete = GetAdminById(id);
            if (adminToDelete == null)
            {
                return false;
            }
            _context.Admins.Remove(adminToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
