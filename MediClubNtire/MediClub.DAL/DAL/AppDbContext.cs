using MediClubModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MediClub.DAL.DAL
{
	public class AppDbContext:IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		DbSet<TestMediPlus> TestMediPluss { get; set; }
		DbSet<Doctor> Doctors { get; set; }
		DbSet<Patient> Patients { get; set; }
		DbSet<Appointment> Appointments { get; set; }
		DbSet<AppUser> AppUsers { get; set; }
        DbSet<Hospital> Hospitals { get; set; }
        DbSet<DoctorHospital> DoctorHospitals { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DoctorHospital>()
            .HasKey(dh => new { dh.DoctorId, dh.HospitalId });

            builder.Entity<DoctorHospital>()
           .HasOne(dh => dh.Doctor)
           .WithMany(d => d.DoctorHospitals)
           .HasForeignKey(dh => dh.DoctorId);

            builder.Entity<DoctorHospital>()
            .HasOne(dh => dh.Hospital)
            .WithMany(h => h.DoctorHospitals)
            .HasForeignKey(dh => dh.HospitalId);
        }
    }
}
