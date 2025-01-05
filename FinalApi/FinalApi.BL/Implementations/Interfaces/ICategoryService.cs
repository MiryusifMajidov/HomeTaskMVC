using FinalApi.Model.DTOs.Category;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(CategoryDto entity);
        Task UpdateAsync(Category entity);
        Task SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
    }
}
