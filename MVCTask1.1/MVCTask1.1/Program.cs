using Microsoft.EntityFrameworkCore;
using MVCTask1._1.Data;

namespace MVCTask1._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

           
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "teacher",
                pattern: "teachers/{action=Index}/{id?}",
                defaults: new { controller = "Teacher" });

            app.MapControllerRoute(
                name: "group",
                pattern: "groups/{action=Index}/{id?}",
                defaults: new { controller = "Group" });

            app.MapControllerRoute(
                name: "student",
                pattern: "students/{action=Index}/{id?}",
                defaults: new { controller = "Student" });

            app.Run();

        }
    }
}

