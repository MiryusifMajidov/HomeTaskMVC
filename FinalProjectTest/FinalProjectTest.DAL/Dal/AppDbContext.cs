using FinalProjectTest.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.DAL.Dal
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions option ):base(option)
        {
            
        }

        DbSet<Cart> Carts { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
    }
}
