using FinalApi.Model.DTOs.Color;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Interfaces
{
    public interface IColorService
    {
        Task<Color> GetByIdAsync(int id);
        Task<IEnumerable<Color>> GetAllAsync();
        Task AddAsync(ColorDto entity);
        Task UpdateAsync(Color entity);
        Task SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
    }
}
