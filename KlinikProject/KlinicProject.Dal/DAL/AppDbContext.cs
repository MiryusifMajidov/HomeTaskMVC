using KlinicProject.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.Dal.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions option):base(option)
        {
            
        }

        DbSet<AppUser> appUsers {  get; set; }
        DbSet<Department> departments { get; set; } 
        DbSet<Doctor> doctors { get; set; }
    }
}
