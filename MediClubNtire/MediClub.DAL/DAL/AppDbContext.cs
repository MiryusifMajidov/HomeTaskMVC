using MediClubModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClub.DAL.DAL
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		DbSet<TestMediPlus> TestMediPluss { get; set; }
		DbSet<Doctor> Doctors { get; set; }
		DbSet<Patient> Patients { get; set; }
		DbSet<Appointment> Appointments { get; set; }
	}
}
