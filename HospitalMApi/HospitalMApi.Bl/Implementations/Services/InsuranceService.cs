using AutoMapper;
using HospitalMApi.Bl.Implementations.Interfaces;
using HospitalMApi.Dal.Implementations.RepositoryIntefaces;
using HospitalMApi.Model.DTOs.Insurance;
using HospitalMApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Bl.Implementations.Services
{
    public class InsuranceService : IInsuranceService
    {

        private readonly IRepository<Insurance> _insuranceService;
        private readonly IMapper _mapper;

        public InsuranceService(IRepository<Insurance> insuranceService, IMapper mapper)
        {
            _insuranceService = insuranceService;
            _mapper = mapper;
        }

        public async Task AddAsync(InsuranceCreateDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "SizeDto cannot be null.");
            }

            var insurance = _mapper.Map<Insurance>(entity);
            await _insuranceService.AddAsync(insurance);

        }

        public async Task<IEnumerable<Insurance>> GetAllAsync()
        {
            return await _insuranceService.GetAll();
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {
            return await GetExistingEntity(id);
        }

        public async Task HardDeleteAsync(int id)
        {
            await GetExistingEntity(id);
            await _insuranceService.HardDelete(id);

        }

        public async Task SoftDeleteAsync(int id)
        {
            await GetExistingEntity(id);
            await _insuranceService.SoftDelete(id);

        }

        public async Task UpdateAsync(InsuranceUpdateDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException( "Insurance cannot be null.");
            }

            Insurance insurance = new Insurance()
            {
                Id = entity.Id,
                PersonInsurance = entity.PersonInsurance,
                Discount = entity.Discount, 
            };
            var existingInsurance = await GetExistingEntity(insurance.Id);
          
            await _insuranceService.Update(insurance);

        }
  
        private async Task<Insurance> GetExistingEntity(int id)
        {
            var insurance = await _insuranceService.GetById(id);
            if (insurance == null)
            {
                throw new KeyNotFoundException($"Insurance with id {id} not found.");
            }
            return insurance;
        }

     
    }
}
