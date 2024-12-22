using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApi.Model.DTOs.Account
{
    public class UserLogin
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool isPersistant { get; set; }

    }
}
