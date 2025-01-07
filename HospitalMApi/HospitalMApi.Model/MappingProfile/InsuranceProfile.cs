using AutoMapper;
using HospitalMApi.Model.DTOs.Insurance;
using HospitalMApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Model.MappingProfile
{
    public class InsuranceProfile:Profile
    {
        public InsuranceProfile()
        {
            CreateMap<InsuranceCreateDto, Insurance>();
            CreateMap<Insurance, InsuranceCreateDto>();
        }
    }
}
