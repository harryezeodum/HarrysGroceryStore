using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IUserRepository
    {
        public User Create(User user);
        
        public IQueryable<User> GetAllUsers();
        
        public User GetUserById(int userId);
        
        public IQueryable<User> GetUsersByKeyword(string keyword);

        public User GetUserByEmailAddress(string emailAddress);

        public bool Login(User u);

        public void Logout();

        public bool IsUserLoggedIn();

        public int GetLoggedInUserId();

        public string GetLoggedInEmail();

        public bool ChangePassword(string oldPassword, string newPassword);

        public string ResetPassword(string emailAddress);

        public User Update(User user);
        
        public bool Delete(int id);
    }
}
