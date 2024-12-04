using InanceDAL.DAL;
using InanceDAL.Interfaces;
using InanceModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceDAL.Implementations
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _context;

		public Repository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		
		}

		

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

        public async Task<T> GetByMaster(int serviceId)
        {
            if (typeof(T) == typeof(Master)) 
            {
                
                var query = _context.Set<Master>()
                    .Where(m => m.ServiceId == serviceId && m.IsActive)
                    .OrderByDescending(m => m.ExperienceYear);

                return await query.FirstOrDefaultAsync() as T; 
            }

            return default; 
        }

        public async Task<T?> UserVerification<T>(string usernameOrEmail) where T : class
        {
            if (typeof(T) == typeof(AppUser))
            {
                var user = await _context.Set<AppUser>()
                    .FirstOrDefaultAsync(x => x.UserName == usernameOrEmail || x.Email == usernameOrEmail);

                return user as T; 
            }

            return default;
        }





        public async Task HardDelete(int id)
		{
			var entity = await GetById(id);
			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task SoftDelete(int id)
		{
			var entity = await GetById(id);
			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task Update(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}

        
    }
}
