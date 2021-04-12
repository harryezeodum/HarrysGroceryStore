using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@aol.com", PhoneNumber = "7134021336", PassWord = "John2020!", ConfirmPassword = "John2020!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 2, FirstName = "Michael", LastName = "Chan", Email = "michael.chan@gmail.com", PhoneNumber = "7135243201", PassWord = "Mike2020!", ConfirmPassword = "Mike2020!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 3, FirstName = "Clarie", LastName = "Ramirez", Email = "claire4real@aol.com", PhoneNumber = "7134278974", PassWord = "beauty", ConfirmPassword = "beauty" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 4, FirstName = "Smith", LastName = "Johnson", Email = "smithJohnson@outlook.com.com", PhoneNumber = "2105412031", PassWord = "smitty1989!", ConfirmPassword = "smitty1989!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 5, FirstName = "Voke", LastName = "Oluwafemi", Email = "voke.oluwafemi@aol.com", PhoneNumber = "7138795214", PassWord = "voke1900!", ConfirmPassword = "voke1900!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 6, FirstName = "Harry", LastName = "Porter", Email = "harryporter@aol.com", PhoneNumber = "7137852140", PassWord = "Porterisgood!", ConfirmPassword = "Porterisgood!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 7, FirstName = "Israel", LastName = "Ruiz", Email = "israelruiz@yahoo.com", PhoneNumber = "7133020145", PassWord = "Realsoccer!", ConfirmPassword = "Realsoccer!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 8, FirstName = "Austin", LastName = "Capstone", Email = "austin.capstone@outlook.com", PhoneNumber = "2103625479", PassWord = "capstone!", ConfirmPassword = "capstone!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 9, FirstName = "Genesis", LastName = "Howard", Email = "genesishoward@aol.com", PhoneNumber = "2104021336", PassWord = "baller21!", ConfirmPassword = "baller21!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 10, FirstName = "Christian", LastName = "Walcot", Email = "christianwalcot@aol.com", PhoneNumber = "7134025241", PassWord = "christian2005!", ConfirmPassword = "christian2005!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 11, FirstName = "Ngozi", LastName = "Offodile", Email = "ngozi.Offodile@gmail.com", PhoneNumber = "7134042035", PassWord = "ngozi2021!", ConfirmPassword = "ngozi2021!" });

            modelBuilder.Entity<User>().HasData(new User { UserId = 12, FirstName = "Adaobi", LastName = "Chukwueze", Email = "adaobieze@yahoo.com", PhoneNumber = "2104021336", PassWord = "ada2020!", ConfirmPassword = "ada2020!" });
        }
    }
}
