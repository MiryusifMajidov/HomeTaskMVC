using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MediClubModel.DTOs
{
    public class DoctorDto
    {
        [Required]
        [Length(3, 50)]
        
        [Display(Prompt = "Name")]
        public string Name { get; set; }

        [Required]
        [Length(3, 50)]
        
        [Display(Prompt = "Surename")]
        public string Surname { get; set; }


        [Required]
        [Length(3, 50)]
       
        [Display(Prompt = "FinKod")]
        public string Finkod { get; set; }


        [Required]
        [Length(3, 50)]
       
        [Display(Prompt = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Length(3, 50)]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }

       public IFormFile Image { get; set; }

    }
}
