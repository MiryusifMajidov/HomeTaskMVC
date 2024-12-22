using DepartmentApi.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApi.DAL.DAL
{
    public class AppDbContext:IdentityDbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AppUser> appUsers { get; set; }
    }
}
