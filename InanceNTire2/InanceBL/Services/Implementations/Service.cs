using InanceBL.Services.Interfaces;
using InanceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceBL.Services.Implementations
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

        public async Task<T> GetByMaster(int serviceId)
        {
            return await _repository.GetByMaster(serviceId);
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

        public async Task<T1> UserVerification<T1>(string usernameOrEmail) where T1 : class
        {
            var result = await _repository.UserVerification<T1>(usernameOrEmail);
            return result; 
        }


    }
}
