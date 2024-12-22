using GameStore.BL.Services.Implementations;
using GameStore.BL.Services.Interfaces;
using GameStore.DAL.DAL;
using GameStore.DAL.Implementations;
using GameStore.DAL.Interfaces;
using GameStore.Model.Models;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace GameStore.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

           
            builder.Services.AddTransient<IEmailSender, EmailSender>();

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
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                await RoleSeeder.SeedRoles(serviceProvider);
            }



            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
