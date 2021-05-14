using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        private ISession _session;

        public UserRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public User Create(User user)
        {
            User existingUser = GetUserByEmailAddress(user.Email);
            if (existingUser != null)
            {
                return null;
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            if (IsUserLoggedIn())
            {
                return _context.Users.Include(u => u.Customer).Where(u => u.UserId == GetLoggedInUserId());
            }
            User[] noUser = new User[0];
            return noUser.AsQueryable<User>();
        }
        
        public User GetUserById(int userId)
        {
            User user = _context.Users.Include(user => user.Customer).Where(user => user.UserId == userId).FirstOrDefault();
            return user;
        }
        
        public IQueryable<User> GetUsersByKeyword(string keyword)
        {
            IQueryable<User> users = _context.Users.Where(p => p.Email.Contains(keyword));
            return users;
        }

        public User GetUserByEmailAddress(string emailAddress)
        {
            return _context.Users.Where(u => u.Email == emailAddress).FirstOrDefault();
        }

        public bool Login(User user)
        {
            User existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.PassWord == user.PassWord);
            if (existingUser == null || existingUser.PassWord != user.PassWord)
            {
                return false;
            }
            else
            {
                _session.SetInt32("userid", existingUser.UserId);
                _session.SetString("email", user.Email);
                return true;
            }
        }

        public void Logout()
        {
            _session.Remove("userid");
            _session.Remove("email");
        }

        public bool IsUserLoggedIn()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetLoggedInUserId()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return -1;
            }
            else
            {
                return userId.Value;
            }
        }

        public string GetLoggedInEmail()
        {
            return _session.GetString("email");
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (! IsUserLoggedIn())
            {
                return false;
            }

            User userToUpdate = GetUserById(GetLoggedInUserId());

            if (userToUpdate != null && userToUpdate.PassWord == oldPassword)
            {
                userToUpdate.PassWord = newPassword;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string ResetPassword(string emailAddress)
        {
            User userToUpdate = GetUserByEmailAddress(emailAddress);

            if (userToUpdate != null)
            {
                userToUpdate.PassWord = ResetPassword();
                _context.SaveChanges();
                return userToUpdate.PassWord;
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

        public User Update(User user)
        {
            User userToUpdate = _context.Users.Find(user.UserId);
        
            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.PassWord = user.PassWord;
                _context.SaveChanges();
            }
            return userToUpdate;
        }
        
        public bool Delete(int id)
        {
            User userToDelete = GetUserById(id);
            if (userToDelete == null)
            {
                return false;
            }
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
