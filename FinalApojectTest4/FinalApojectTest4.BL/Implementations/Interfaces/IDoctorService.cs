using FinalApojectTest4.Model.Dtos.DepartmentDtos;
using FinalApojectTest4.Model.Dtos.DoctorsDtos;
using FinalApojectTest4.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.BL.Implementations.Interfaces
{
    public interface IDoctorService
    {
        Task CreateAsync(GetDoctorDto entity);
        Task<IEnumerable<GetDoctorDto>> GetAll();
        Task<GetDoctorDto> GetById(int id);
        Task Delete(GetDoctorDto entity);
        Task Update(GetDoctorDto entity);
    }
}
