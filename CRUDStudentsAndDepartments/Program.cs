using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using CRUDStudentsAndDepartments.Repos;
using CRUDStudentsAndDepartments.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartment, DepartmentService>();
            builder.Services.AddScoped<IStudent, StudentService>();
            builder.Services.AddScoped<IEntity<Course>,GService<Course>>();
            builder.Services.AddScoped<CheckEmailService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.LoginPath = "/User/Login";

                    }
                );
            builder.Services.AddDbContext<MvcDbContext>(
                s => {
                    s.UseSqlServer("Server=.\\SQLexpress;Database=MVCCRUDITI;Trusted_Connection=True;TrustServerCertificate=True;");
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

           // app.Use(
           //    async (context, next) =>
           //    {
           //        await context.Response.WriteAsync("hello from use \n");
           //        await next.Invoke();
           //        await context.Response.WriteAsync("welcome again \n");
           //    }
           //);

           // app.Run(
           //     async context =>
           //     {
           //         await context.Response.WriteAsync("Hello from run \n");
           //     }
           //     );


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
