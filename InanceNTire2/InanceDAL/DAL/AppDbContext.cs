using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InanceModels.Models;

namespace InanceDAL.DAL
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<ntiretest> ntiretests { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
               .HasOne(o => o.Service)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
               .HasOne(o => o.Master)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.MasterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Master>()
               .HasOne(m => m.Service)
                .WithMany(s => s.Masters)
                .HasForeignKey(m => m.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
