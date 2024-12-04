using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClubModel.DTOs
{
    public class HospitalDto
    {

        [Required]
        [Length(2, 100)]

        [Display(Prompt = "Hosbital Name")]
        public string HospitalName { get; set; }
    }
}
