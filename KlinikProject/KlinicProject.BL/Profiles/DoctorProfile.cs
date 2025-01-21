using AutoMapper;
using KlinicProject.Model.Dtos.DepartmentDtos;
using KlinicProject.Model.Dtos.DoctorDtos;
using KlinicProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.BL.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorCreateDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorGetDto, Doctor>();
            CreateMap<Doctor, DoctorGetDto>();
            CreateMap<DoctorCreateDto, DoctorGetDto>();
            CreateMap<DoctorGetDto, DoctorCreateDto>();
            
        }
    }
}
