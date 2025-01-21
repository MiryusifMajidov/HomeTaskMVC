using KlinicProject.Model.Dtos.DepartmentDtos;
using KlinicProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinicProject.BL.Implementations.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentGetDto>> GetAllAsync();
        Task<DepartmentGetDto> GetById(int id);
        Task CreateAsync(DepartmentCreateDto entity);
        Task Update(DepartmentCreateDto entity, int id);
        Task Delete(int id);

    }
}
