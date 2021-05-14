using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 1, FirstName = "Genesis", LastName = "Howard", PhoneNumber = "281-789-1201", Address = "10612 Smith Street", City = "Pasadena", State = "Texas", ZipCode = "77786" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 2, FirstName = "Christian", LastName = "Walcot", PhoneNumber = "281-789-1201", Address = "588 Alington Place", City = "Pearland", State = "Texas", ZipCode = "77394" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 3, FirstName = "Ngozi", LastName = "Offodile", PhoneNumber = "281-213-0090", Address = "12145 South Loop West", City = "Houston", State = "Texas", ZipCode = "77092" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 4, FirstName = "Adaobi", LastName = "Eze", PhoneNumber = "713-356-2190", Address = "10612 Barker Street", City = "Katy", State = "Texas", ZipCode = "77492" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 5, FirstName = "Tichelle", LastName = "Miller", PhoneNumber = "713-214-3345", Address = "1239 Katy Lane #2512", City = "Crypress", State = "Texas", ZipCode = "77041" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 6, FirstName = "Christian", LastName = "Biden", PhoneNumber = "713-756-5412", Address = "10612 Holly Spring Ln", City = "Katy", State = "Texas", ZipCode = "77125" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 7, FirstName = "Mary", LastName = "Jaden", PhoneNumber = "281-789-1854", Address = "612 Allan Street", City = "Houston", State = "Texas", ZipCode = "77754" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 8, FirstName = "Jude", LastName = "Oladipo", PhoneNumber = "281-451-1201", Address = "1612 London Circle", City = "Richmond Hills", State = "Texas", ZipCode = "77203" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 9, FirstName = "Chioma", LastName = "Branch", PhoneNumber = "281-789-0254", Address = "5647 Smith Street", City = "Spring", State = "Texas", ZipCode = "77785" });

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 10, FirstName = "Jude", LastName = "Offodile", PhoneNumber = "281-784-8901", Address = "8963 Houston Street", City = "Houston", State = "Texas", ZipCode = "77251" });

            modelBuilder.Entity<Admin>().HasIndex(a => a.Email).IsUnique();

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 1, Email = "johndoe@aol.com", PassWord = "baller21!", EmployeeId = 1 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 2, Email = "michaelchan@aol.com", PassWord = "christian2005!", EmployeeId = 2 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 3, Email = "clairejonnas@gmail.com", PassWord = "ngozi2021!", EmployeeId = 3 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 4, Email = "smith.johnson@gmail.com", PassWord = "ada2020!", EmployeeId = 4 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 5, Email = "vokeoluwafemi@aol.com", PassWord = "ada2020!", EmployeeId = 5 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 6, Email = "harryporter@yahoo.com", PassWord = "ada2020!", EmployeeId = 6 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 7, Email = "israelruiz@outlook.com", PassWord = "ada2020!", EmployeeId = 7 });

            modelBuilder.Entity<Admin>().HasData(new Admin { AdminId = 8, Email = "austin.capstone@outlook.com", PassWord = "ada2020!", EmployeeId = 8 });


            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Email = "genesishoward@aol.com", PassWord = "baller21!", CustomerId = 1});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, Email = "christianwalcot@aol.com", PassWord = "christian2005!", CustomerId = 2});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, Email = "ngozi.Offodile@gmail.com", PassWord = "ngozi2021!", CustomerId = 3});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 4, Email = "adaobieze@gmail.com", PassWord = "ada2020!", CustomerId = 4});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 5, Email = "tichellemiller@aol.com", PassWord = "ada2020!", CustomerId = 5});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 6, Email = "christainbiden@yahoo.com", PassWord = "ada2020!", CustomerId = 6});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 7, Email = "maryjaden@outlook.com", PassWord = "ada2020!", CustomerId = 7});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 8, Email = "judeoladipo@outlook.com", PassWord = "ada2020!", CustomerId = 8});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 9, Email = "chioma.branch@aol.com", PassWord = "ada2020!", CustomerId = 9});
            
            modelBuilder.Entity<User>().HasData(new User { UserId = 10, Email = "judeoffodile@yahoo.com", PassWord = "ada2020!", CustomerId = 10});

            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", HireDate = "11/01/2015", PhoneNumber = "281-216-9087", Address = "2314 GrandVille Pkwy", City = "Sugarland", State = "Texas", ZipCode = "77201"});
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 2, FirstName = "Michael", LastName = "Chan", HireDate = "12/01/2015", PhoneNumber = "713-623-3212", Address = "7865 Swine Street #214", City = "Houston", State = "Texas", ZipCode = "77043" });
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 3, FirstName = "Claire", LastName = "Jonnas", HireDate = "02/01/2016", PhoneNumber = "281-203-1204", Address = "30213 Oliver Ln", City = "Crypress", State = "Texas", ZipCode = "77901" });
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 4,  FirstName = "Smith", LastName = "Johnson", HireDate = "03/01/2016", PhoneNumber = "713-897-9087", Address = "23156 Hills Street #123", City = "Richmond", State = "Texas", ZipCode = "77874" });
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 5, FirstName = "Voke", LastName = "Oluwafemi", HireDate = "04/01/2016", PhoneNumber = "281-985-6675", Address = "14562 Holly Spring Cir", City = "Cinco", State = "Texas", ZipCode = "77523" });
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 6, FirstName = "Harry", LastName = "Porter", HireDate = "05/01/2016", PhoneNumber = "281-785-7842", Address = "'23145 Richmond Avenue", City = "Sugarland", State = "Texas", ZipCode = "77244" });
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 7, FirstName = "Israel", LastName = "Ruiz", HireDate = "06/01/2016", PhoneNumber = "713-854-8741", Address = "12786 Galley Lane #456", City = "Richmond", State = "Texas", ZipCode = "77879" });
            
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 8, FirstName = "Austin", LastName = "Capstone", HireDate = "07/01/2016", PhoneNumber = "281-741-1032", Address = "89065 Small Lan", City = "Cinco", State = "Texas", ZipCode = "77510" });
            
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 1, CompanyName = "Amingo Inc.", ContactName = "Cameron, Harry", ContactEmail = "cameron.harry@amingo.com", ContactPhone = "713-520-2103" });
            
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 2, CompanyName = "Josh Brothers", ContactName = "Doyle Judy", ContactEmail = "doyle.Judy@joshbrothers.net", ContactPhone = "281-453-0976" });
            
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 3, CompanyName = "Jimmy Wholesale Food", ContactName = "Marie, Herz", ContactEmail = "marie.herz@jimmywholesalefood.com", ContactPhone = "281-745-894" });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, SupplierId = 1, ProductName = "Doritos Chips", Category = "Snacks", Price = 10M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 2, SupplierId = 2, ProductName = "Hawaiian Bread", Category = "Pantry", Price = 10M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 3, SupplierId = 1, ProductName = "H-E-B Original Apple Sauce", Category = "Dairy", Price = 20M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 4, SupplierId = 1, ProductName = "Nabisco Sweet Treats Cookie", Category = "Snacks", Price = 10M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 5, SupplierId = 3, ProductName = "Evian Natural Spring Water", Category = "Beverages", Price = 10M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 6, SupplierId = 2, ProductName = "Velveeta Shells & Cheese", Category = "Pantry", Price = 20M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 7, SupplierId = 2, ProductName = "Betty Crocker Bisquick Shake Pancakes", Category = "Breakfast & Cereal", Price = 11M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 8, SupplierId = 3, ProductName = "Vita Coco Coconut Water", Category = "Beverages", Price = 16M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 9, SupplierId = 2, ProductName = "6 Pack Hormel Compleats Spaghetti", Category = "Pantry", Price = 8M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 10, SupplierId = 2, ProductName = "Butternut Mountain 100% Farm Syrup", Category = "Breakfast & Cereal", Price = 20M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 11, SupplierId = 1, ProductName = "Egg-Land Best Organic Egg", Category = "Dairy", Price = 6M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 12, SupplierId = 3, ProductName = "Coffee Mate Pack of 2", Category = "Beverages", Price = 10M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 13, SupplierId = 2, ProductName = "BetterBody Foods Pure Avocado Oil", Category = "Pantry", Price = 11M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 14, SupplierId = 2, ProductName = "Quaker Grits pack of 2", Category = "Breakfast & Cereal", Price = 9M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 15, SupplierId = 2, ProductName = "Barilla Classic Blue Box Pasta", Category = "Pantry", Price = 10M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 16, SupplierId = 3, ProductName = "Ocean Spray 100% Orange Juice", Category = "Beverages", Price = 20M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 17, SupplierId = 2, ProductName = "Mahatma Enriched Extra Long Grain", Category = "Pantry", Price = 11M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 18, SupplierId = 2, ProductName = "Kellogg's Corn Flakes pack of 2", Category = "Breakfast & Cereal", Price = 8M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 19, SupplierId = 1, ProductName = "Dole Fruit Bowls Variety Pack", Category = "Dairy", Price = 13M });
            
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 20, SupplierId = 3, ProductName = "Pepsi Soda (2 pack)", Category = "Beverages", Price = 15M });            
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10001, CustomerId = 1, EmployeeId = 8, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 50M, ShipAddress = "10612 Smith Street", ShipCity = "Pasadena", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10002, CustomerId = 2, EmployeeId = 7, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 30M, ShipAddress = "588 Alington Place", ShipCity = "Pearland", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10003, CustomerId = 3, EmployeeId = 6, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 40M, ShipAddress = "12145 South Loop West", ShipCity = "Houston", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10004, CustomerId = 4, EmployeeId = 5, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 60M, ShipAddress = "10612 Barker Street", ShipCity = "Katy", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10005, CustomerId = 5, EmployeeId = 4, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 70M, ShipAddress = "1239 Katy Lane #2512", ShipCity = "Crypress", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10006, CustomerId = 6, EmployeeId = 8, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 80M, ShipAddress = "10612 Holly Spring Ln", ShipCity = "Katy", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10007, CustomerId = 7, EmployeeId = 7, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 44M, ShipAddress = "612 Allan Street", ShipCity = "Houston", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10008, CustomerId = 8, EmployeeId = 6, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 64M, ShipAddress = "1612 London Circle", ShipCity = "Richmond Hills", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10009, CustomerId = 9, EmployeeId = 5, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 24M, ShipAddress = "5647 Smith Street", ShipCity = "Spring", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 10010, CustomerId = 10, EmployeeId = 4, OrderDate = "02/21/2021", ShippedDate = "02/22/2021", SalesAmount = 60M, ShipAddress = "8963 Houston Street", ShipCity = "Houston", State = "Texas", Zipcode = "77786" });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10001, OrderId = 10001, ProductId = 1, UnitPrice = 10M, Quantity = 5 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10002, OrderId = 10002, ProductId = 2, UnitPrice = 10M, Quantity = 3 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10003, OrderId = 10003, ProductId = 3, UnitPrice = 20M, Quantity = 2 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10004, OrderId = 10004, ProductId = 4, UnitPrice = 10M, Quantity = 6 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10005, OrderId = 10005, ProductId = 5, UnitPrice = 10M, Quantity = 7 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10006, OrderId = 10006, ProductId = 6, UnitPrice = 20M, Quantity = 4 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10007, OrderId = 10007, ProductId = 7, UnitPrice = 11M, Quantity = 4 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10008, OrderId = 10008, ProductId = 8, UnitPrice = 16M, Quantity = 4 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10009, OrderId = 10009, ProductId = 9, UnitPrice = 8M, Quantity = 3 });
            
            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail { OrderDetailId = 10010, OrderId = 10010, ProductId = 10, UnitPrice = 20M, Quantity = 3 });
        }
    }
}
