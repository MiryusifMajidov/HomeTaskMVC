using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClubModel.Models
{
	public class Appointment:BaseEntity
	{
		
		public int DoctorId { get; set; }
		public Doctor Doctor { get; set; } 

		public int PatientId { get; set; }
		public Patient Patient { get; set; }

		public DateTime AppointmentDate { get; set; }
		public bool IsActive { get; set; }
	}
}
