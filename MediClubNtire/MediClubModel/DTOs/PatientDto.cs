using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClubModel.DTOs
{
    public class PatientDto
    {

        [Required]
        [Length(3, 50)]
        
        [Display(Prompt = "Name")]
        public string Name { get; set; }

        [Required]
        [Length(3, 50)]
        
        [Display(Prompt = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Length(3, 50)]
        
        [Display(Prompt = "Finkod")]
        public string Finkod { get; set; }

        [Required]
        [Length(3, 50)]
        
        [Display(Prompt = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        
    }
}
