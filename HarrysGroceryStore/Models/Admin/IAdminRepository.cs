using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IAdminRepository
    {
        public Admin Create(Admin a);

        public IQueryable<Admin> GetAllAdmins();

        public Admin GetAdminById(int adminId);

        public IQueryable<Admin> GetAdminByKeyword(string keyword);

        public Admin GetAdminByEmailAddress(string emailAddress);

        public bool EmployeePortal(Admin admin);

        public void Logout();

        public bool IsAdminLoggedIn();

        public int GetLoggedInAdminId();

        public string GetLoggedInEmail();

        public bool ChangePassword(string oldPassword, string newPassword);

        public string ResetPassword(string emailAddress);

        public Admin Update(Admin a);

        public bool Delete(int id);
    }
}
