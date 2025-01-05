using AutoMapper;
using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Dal.Interfaces;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Services
{
    public class SizeService : ISizeService
    {
        private readonly IRepository<Size> _repository;
        private readonly IMapper _mapper;

        public SizeService(IRepository<Size> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(SizeDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "SizeDto cannot be null.");
            }

            var size = _mapper.Map<Size>(entity);
            await _repository.AddAsync(size);
            
        }

        public async Task<IEnumerable<Size>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await GetExistingEntity(id);
        }

        public async Task HardDeleteAsync(int id)
        {
            await GetExistingEntity(id);
            await _repository.HardDelete(id);
            
        }

        public async Task SoftDeleteAsync(int id)
        {
            await GetExistingEntity(id);
            await _repository.SoftDelete(id);
            
        }

        public async Task UpdateAsync(Size entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Size cannot be null.");
            }

            var existingSize = await GetExistingEntity(entity.Id);
            existingSize.Name = entity.Name; 
            await _repository.Update(existingSize);
           
        }

        private async Task<Size> GetExistingEntity(int id)
        {
            var size = await _repository.GetById(id);
            if (size == null)
            {
                throw new KeyNotFoundException($"Size with id {id} not found.");
            }
            return size;
        }
    }
}
