using AutoMapper;
using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Dal.Interfaces;
using FinalApi.Model.DTOs.Category;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "CategoryDto cannot be null.");
            }

            var category = _mapper.Map<Category>(entity);
            await _repository.AddAsync(category);
           
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Category> GetByIdAsync(int id)
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

        public async Task UpdateAsync(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Category cannot be null.");
            }

            var existingCategory = await GetExistingEntity(entity.Id);
            existingCategory.Name = entity.Name;
           
            await _repository.Update(existingCategory);
            
        }

        private async Task<Category> GetExistingEntity(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }
            return category;
        }
    }
}
