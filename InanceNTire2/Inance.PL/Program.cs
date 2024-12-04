using InanceBL.Services.Implementations;
using InanceBL.Services.Interfaces;
using InanceDAL.DAL;
using InanceDAL.Implementations;
using InanceDAL.Interfaces;
using InanceModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Inance.PL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<AppDbContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


            var app = builder.Build();


			app.UseStaticFiles();
			//app.UseAuthentication();

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




