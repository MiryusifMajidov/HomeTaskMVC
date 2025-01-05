using AutoMapper;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.MappingProfile.SizeProfiles
{
    public class SizeProfile:Profile
    {
        public SizeProfile() 
        {   
                CreateMap<SizeDto, Size>();
                CreateMap<Size, SizeDto>();
        }
    }
}
