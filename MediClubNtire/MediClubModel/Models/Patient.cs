using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClubModel.Models
{
	public class Patient:BaseEntity
	{
		
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Finkod { get; set; }
		public string PhoneNumber { get; set; }
		public string Username { get; set; }
		public bool IsDeleted { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
	}
}
