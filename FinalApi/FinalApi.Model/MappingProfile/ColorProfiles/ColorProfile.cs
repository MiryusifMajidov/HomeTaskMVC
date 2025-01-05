using AutoMapper;
using FinalApi.Model.DTOs.Color;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.MappingProfile.ColorProfiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile() 
        {
            CreateMap<ColorDto, Color>();
            CreateMap<Color, ColorDto>();
        }
    }
}
