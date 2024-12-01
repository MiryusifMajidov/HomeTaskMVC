using MediClubModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClubModel.DTOs
{
    public class AppointmentDto
    {

        [Required]
        
        public int DoctorId { get; set; }

        [Required]
       

        public int PatientId { get; set; }


        public DateTime AppointmentDate { get; set; }
    }
}
