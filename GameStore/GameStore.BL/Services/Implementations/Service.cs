﻿using GameStore.BL.Services.Interfaces;
using GameStore.DAL.Interfaces;
using GameStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Services.Implementations
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

       

        public async Task HardDeleteAsync(int id)
        {
            await _repository.HardDelete(id);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _repository.SoftDelete(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.Update(entity);
        }

        public async Task<List<Comment>> GetByCommentAsync(int id)
        {
           
            return await _repository.GetByComment(id);
        }
            


    }
}
