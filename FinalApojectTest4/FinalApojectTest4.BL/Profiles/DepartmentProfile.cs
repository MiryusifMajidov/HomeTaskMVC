using AutoMapper;
using FinalApojectTest4.Model.Dtos.DepartmentDtos;
using FinalApojectTest4.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.BL.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, CreateDepartmentDto>();
            CreateMap<CreateDepartmentDto, Department>();
        }
    }
}
