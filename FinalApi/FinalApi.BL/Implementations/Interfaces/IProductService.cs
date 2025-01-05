using FinalApi.Model.DTOs.Color;
using FinalApi.Model.DTOs.Product;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(CreateProductDto entity);
        Task UpdateAsync(Product entity);
        Task SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
    }
}
