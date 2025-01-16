using FinalApojectTest4.Model.Dtos.DepartmentDtos;
using FinalApojectTest4.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.BL.Implementations.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<GetDepartmentDto>> GetAll();
        Task<GetDepartmentDto> GetById(int id);
        Task Delete(GetDepartmentDto entity);
        Task CreateAsync(CreateDepartmentDto entity);
        Task Update(GetDepartmentDto entity);
    }
}
