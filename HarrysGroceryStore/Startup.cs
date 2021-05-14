using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAdminRepository, EfAdminRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
            services.AddScoped<IOrderDetailRepository, EfOrderDetailRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<ISupplierRepository, EfSupplierRepository>();
            services.AddScoped<IEmailRepository, GmailEmailRepository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession(
               options =>
               {
                  options.IdleTimeout = TimeSpan.FromMinutes(20);
               }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("adminpagination", "Admins/Page{adminPage}", new { Controller = "Admin", action = "Index" });

                endpoints.MapControllerRoute("userpagination", "Users/Page{userPage}", new { Controller = "User", action = "Index" });
                
                endpoints.MapControllerRoute("customerpagination", "Customers/page{customerPage}", new { Controller = "Customer", action = "Index" });

                endpoints.MapControllerRoute("customerpagination", "Customers/page{customerPage}", new { Controller = "Customer", action = "CustomerIndex" });

                endpoints.MapControllerRoute("employeepagination", "Employees/Page{employeePage}", new { Controller = "Employee", action = "Index" });

                endpoints.MapControllerRoute("employeepagination", "Employees/Page{employeePage}", new { Controller = "Employee", action = "EmployeeIndex" });

                endpoints.MapControllerRoute("orderdetailpagination", "OrderDetails/Page{orderDetailPage}", new { Controller = "OrderDetail", action = "Index" });
                
                endpoints.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new { Controller = "Product", action = "Index"});
                
                endpoints.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Product", action = "Index"});
                
                endpoints.MapControllerRoute("category", "{category}", new { Controller = "Product", action = "Index" });
                
                endpoints.MapControllerRoute("productpagination", "Products/page{productPage}", new { Controller = "Product", action = "Index", productPage = 1 });
                
                endpoints.MapControllerRoute("orderpagination", "Orders/Page{orderPage}", new { Controller = "Order", action = "Index" });

                endpoints.MapControllerRoute("orderpagination", "Orders/Page{orderPage}", new { Controller = "Order", action = "OrderIndex" });

                endpoints.MapControllerRoute("supplierpagination", "Suppliers/Page{supplierPage}", new { Controller = "Supplier", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=WelcomePage}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
