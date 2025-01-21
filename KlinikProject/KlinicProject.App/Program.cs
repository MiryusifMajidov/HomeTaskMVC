using AutoMapper;
using KlinicProject.BL.Implementations.Interfaces;
using KlinicProject.BL.Implementations.Services;
using KlinicProject.BL.Profiles;
using KlinicProject.Dal.DAL;
using KlinicProject.Dal.Repositories;
using KlinicProject.Model.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace KlinicProject.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
          
          

            builder.Services.AddIdentity<AppUser, IdentityRole>(
            opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddAutoMapper(typeof(DepartmentProfile));
            builder.Services.AddAutoMapper(typeof(DoctorProfile));
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}"
         );

            app.Run();
        }
    }
}
