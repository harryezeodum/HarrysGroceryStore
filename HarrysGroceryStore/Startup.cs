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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("AzureDatabase")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
            services.AddScoped<IOrderDetailRepository, EfOrderDetailRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ISalesOrderRepository, EfSalesOrderRepository>();
            services.AddScoped<ISupplierRepository, EfSupplierRepository>();
            services.AddControllersWithViews();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("pigination", "Users/Page{userPage}", new { Controller = "User", action = "Index" });
                endpoints.MapControllerRoute("pigination", "Customers/Page{customerPage}", new { Controller = "Customer", action = "Index" });
                endpoints.MapControllerRoute("pigination", "Employees/Page{employeePage}", new { Controller = "Employee", action = "Index" });
                endpoints.MapControllerRoute("pigination", "OrderDetails/Page{orderDetailPage}", new { Controller = "OrderDetail", action = "Index" });
                endpoints.MapControllerRoute("pigination", "Products/Page{productPage}", new { Controller = "Product", action = "Index" });
                endpoints.MapControllerRoute("pigination", "SalesOrders/Page{salesOrderPage}", new { Controller = "SalesOrder", action = "Index" });
                endpoints.MapControllerRoute("pigination", "Suppliers/Page{supplierPage}", new { Controller = "Supplier", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=WelcomePage}/{id?}");

                //endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
