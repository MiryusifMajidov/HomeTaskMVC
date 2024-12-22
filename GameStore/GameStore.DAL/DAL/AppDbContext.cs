using GameStore.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> games { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


           /* modelBuilder.Entity<Comment>()
              .HasOne(o => o.Game)
               .WithMany(s => s.Comments)
               .HasForeignKey(o => o.ProductId)
               .OnDelete(DeleteBehavior.Restrict);*/

            builder.Entity<Comment>()
                .HasOne(o=>o.Game)
                .WithMany(o=>o.Comments)
                .HasForeignKey(o=>o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
