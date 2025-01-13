using FinalProjectTest.Model.Dtos.CartDtos;
using FinalProjectTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.BL.Implementation.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart?> GetByIdAsync(int Id);
        Task InsertAsync(CreateCartDto Entity);
        Task UpdateAsync(UpdateCartDto Entity);
        Task DeleteAsync(int Id);
        Task SaveAsync();
    }
}
