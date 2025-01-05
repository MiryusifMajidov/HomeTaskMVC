using FinalApi.Model.DTOs.User;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Interfaces
{
    public interface IRegisterService
    {
        Task<AppUser> RegisterAsync(CreateUserDto userDto);
      
       
        
    }
}
