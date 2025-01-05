
using FinalApi.BL.Implementations.Interfaces;
using FinalApi.BL.Implementations.Services;
using FinalApi.Dal.DAL;
using FinalApi.Dal.Implementations;
using FinalApi.Dal.Interfaces;
using FinalApi.Model.MappingProfile.CategoryProfiles;
using FinalApi.Model.MappingProfile.ColorProfiles;
using FinalApi.Model.MappingProfile.SizeProfiles;
using FinalApi.Model.MappingProfile.UserProfiles;
using FinalApi.Model.Models;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinalApi.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IEmailSender, EmailSender>();

            // Add services to the container.

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IRegisterService, RegisterService>();
            builder.Services.AddScoped<ISizeService, SizeService>();
            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<JwtService>();
        
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));


            builder.Services.AddIdentity<AppUser, IdentityRole>(
               opt =>
               {
                   opt.User.RequireUniqueEmail = true;
                   opt.SignIn.RequireConfirmedEmail = true;
               }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddAutoMapper(typeof(SizeProfile));
            builder.Services.AddAutoMapper(typeof(ColorProfile));
            builder.Services.AddAutoMapper(typeof(CategoryProfile));

            var app = builder.Build();

         /*   using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                await RoleSeeder.SeedRoles(serviceProvider);
            }*/

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
