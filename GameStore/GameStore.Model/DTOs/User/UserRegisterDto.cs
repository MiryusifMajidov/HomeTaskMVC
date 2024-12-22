using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model.DTOs.User
{
    public class UserRegisterDto
    {
        [Required]
        [Length(3, 40)]
        [Display(Prompt = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Length(2, 40)]
        [Display(Prompt = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [Display(Prompt = "Email Name")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [Display(Prompt = "Username")]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = " something is wrong")]
        [Display(Prompt = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
