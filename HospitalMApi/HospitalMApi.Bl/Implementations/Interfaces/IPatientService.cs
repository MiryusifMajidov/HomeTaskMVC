using HospitalMApi.Model.DTOs.Patient;
using HospitalMApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Bl.Implementations.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task AddAsync(PatientCreateDto entity);
        Task UpdateAsync(PatientUpdateDto entity);
        Task SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
       
    }
}
