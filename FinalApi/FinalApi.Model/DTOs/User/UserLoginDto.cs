using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.DTOs.User
{
    public class UserLoginDto
    {
        public string Username { get; set; }  
        public string Password { get; set; } 
        public bool RememberMe { get; set; }
    }
}
