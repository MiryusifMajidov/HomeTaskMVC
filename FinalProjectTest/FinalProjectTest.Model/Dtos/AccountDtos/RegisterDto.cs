using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Model.Dtos.AccountDtos
{
    public class RegisterDto
    {

        [Required]
        [Display(Prompt = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Prompt = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Prompt = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Prompt = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Prompt = "RepeatPassword")]
        public string RepeatPassword { get; set; }
    }
}
