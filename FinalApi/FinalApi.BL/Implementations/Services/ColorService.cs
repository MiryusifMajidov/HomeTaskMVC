using AutoMapper;
using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Dal.Interfaces;
using FinalApi.Model.DTOs.Color;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Services
{
    public class ColorService : IColorService
    {
        private readonly IRepository<Color> _repository;
        private readonly IMapper _mapper;

        public ColorService(IRepository<Color> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ColorDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "ColorDto cannot be null.");
            }

            var color = _mapper.Map<Color>(entity);
            await _repository.AddAsync(color);
           
        }

        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Color> GetByIdAsync(int id)
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

        public async Task UpdateAsync(Color entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Color cannot be null.");
            }

            var existingColor = await GetExistingEntity(entity.Id);
            existingColor.Name = entity.Name; 
            await _repository.Update(existingColor);
           
        }

        private async Task<Color> GetExistingEntity(int id)
        {
            var color = await _repository.GetById(id);
            if (color == null)
            {
                throw new KeyNotFoundException($"Color with id {id} not found.");
            }
            return color;
        }
    }
}
