using AutoMapper;
using FinalApi.Model.DTOs.User;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.MappingProfile.UserProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, AppUser>();
        }
    }
}
