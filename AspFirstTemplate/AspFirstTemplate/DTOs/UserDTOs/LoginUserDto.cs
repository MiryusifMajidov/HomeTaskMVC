using System.ComponentModel.DataAnnotations;

namespace AspFirstTemplate.DTOs.UserDTOs
{
    public class LoginUserDto
    {
        [Required]
        [Display(Prompt ="Username or Email")]
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password), Required]
        [Display(Prompt ="Password")]
        public string Password { get; set; }

        
        public bool isPersistant { get; set; }
    }
}
