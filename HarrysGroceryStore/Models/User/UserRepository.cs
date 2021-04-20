using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }
        
        public User GetUserById(int userId)
        {
            User user = _context.Users.Find(userId);
            return user;
        }
        
        public IQueryable<User> GetUsersByKeyword(string keyword)
        {
            IQueryable<User> users = _context.Users.Where(p => p.Email.Contains(keyword));
            return users;
        }
        
        public User UpdateUser(User user)
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
        
        public bool DeleteUser(int id)
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
