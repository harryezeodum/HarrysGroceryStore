using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IUserRepository
    {
        public User CreateUser(User user);
        
        public IQueryable<User> GetAllUsers();
        
        public User GetUserById(int userId);
        
        public IQueryable<User> GetUsersByKeyword(string keyword);
        
        public User UpdateUser(User user);
        
        public bool DeleteUser(int id);
    }
}
