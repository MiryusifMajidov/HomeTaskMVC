using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.DTOs.UserDTOs
{
    public class LoginDto
    {
        [Required]
        [Display(Prompt = "Username or Email")]
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password), Required]
        [Display(Prompt = "Password")]
        public string Password { get; set; }



        public bool? IsPersistent { get; set; }
    }
}
