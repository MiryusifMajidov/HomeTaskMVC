using HospitalMApi.Model.DTOs.Insurance;
using HospitalMApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Bl.Implementations.Interfaces
{
    public interface IInsuranceService
    {
        Task<Insurance> GetByIdAsync(int id);
        Task<IEnumerable<Insurance>> GetAllAsync();
        Task AddAsync(InsuranceCreateDto entity);
        Task UpdateAsync(InsuranceUpdateDto entity);
        Task SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);


    }
}
