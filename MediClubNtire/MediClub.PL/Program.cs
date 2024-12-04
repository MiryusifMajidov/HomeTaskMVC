using MediClub.BL.Services.Implementations;
using MediClub.BL.Services.Interfaces;
using MediClub.DAL.DAL;
using MediClub.DAL.Implementations;
using MediClub.DAL.Interfaces;
using MediClubModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediClub.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

			/*builder.Services.AddIdentity<AppUser, IdentityRole>(opt=> 
			{
				opt.User.RequireUniqueEmail = true;
				opt.Password.RequiredLength = 3;
			}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();*/

			builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


			var app = builder.Build();

            app.UseStaticFiles();

			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
        }
    }
}
