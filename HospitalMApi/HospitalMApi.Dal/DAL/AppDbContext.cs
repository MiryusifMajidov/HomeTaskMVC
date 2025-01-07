using HospitalMApi.Dal.DAL.Configurations;
using HospitalMApi.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Dal.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        
        DbSet<Insurance> Insurances { get; set; }
        DbSet<Patient> Patients { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new InsuranceConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
