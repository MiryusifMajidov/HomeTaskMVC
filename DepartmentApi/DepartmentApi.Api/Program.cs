
using DepartmentApi.BL.Interfaces;
using DepartmentApi.BL.Services;
using DepartmentApi.DAL.DAL;
using DepartmentApi.DAL.Implementations;
using DepartmentApi.DAL.Interfaces;
using DepartmentApi.Model.Models;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DepartmentApi.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();


            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddAuthorization();


            builder.Services.AddIdentity<AppUser, IdentityRole>(
                opt =>
                {  
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                await RoleSeeder.SeedRoles(serviceProvider);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
