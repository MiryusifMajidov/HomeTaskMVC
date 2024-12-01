using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClub.BL.Services.Interfaces
{
	public interface IService<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task SoftDeleteAsync(int id);
		Task HardDeleteAsync(int id);
		
	}
}
