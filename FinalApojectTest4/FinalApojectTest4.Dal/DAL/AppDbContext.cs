using FinalApojectTest4.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.Dal.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions optons) :base(optons) { }


        DbSet<AppUser> appUsers {  get; set; }
        DbSet<Doctor> doctors { get; set; }
        DbSet<Department> departments { get; set; } 
       
    }
}
