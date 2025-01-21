using AutoMapper;
using KlinicProject.Model.Dtos.DepartmentDtos;
using KlinicProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.BL.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentCreateDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentGetDto, Department>();
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentCreateDto, DepartmentGetDto>();
            CreateMap<DepartmentGetDto, DepartmentCreateDto>();
        }
    }
}
