using KlinicProject.Model.Dtos.DepartmentDtos;
using KlinicProject.Model.Dtos.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.BL.Implementations.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorGetDto>> GetAllAsync();
        Task<DoctorGetDto> GetById(int id);
        Task CreateAsync(DoctorCreateDto entity);
        Task Update(DoctorCreateDto entity, int id);
        Task Delete(int id);
    }
}
