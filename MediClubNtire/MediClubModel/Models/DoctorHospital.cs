using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClubModel.Models
{
    public class DoctorHospital:BaseEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
