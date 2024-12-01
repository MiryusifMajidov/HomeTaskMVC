using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.DTOs
{
    public class MasterDto
    {
        [Required]
        [Length(3, 40)]
        [Display(Prompt = "Name")]
        public string Name { get; set; }

        [Required]
        [Length(3, 40)]
        [Display(Prompt = "Surname")]
        public string Surname { get; set; }

        [Required]
       
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }

        [Required]
        [Length(3, 40)]
        [Display(Prompt = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [Length(3, 15)]
        [Display(Prompt = "Title")]
        public string Username { get; set; }

        [Required]
        [Display(Prompt = "Tecrube ili")]
        public int ExperienceYear { get; set; }

        [Required]
        public int ServiceId { get; set; }
    }
}
