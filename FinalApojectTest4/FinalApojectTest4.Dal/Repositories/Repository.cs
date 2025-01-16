using FinalApojectTest4.Dal.DAL;
using FinalApojectTest4.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.Dal.Repositories
{
    public class Repository<T> : IRepsitory<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

      

        public async Task<int> SaveChangeAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public async Task<T?> GetByIdAsync(int id, bool isTracking, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            T? entity = await query.SingleOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public async Task<T?> GetSingleByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();

            T? entity = await query.SingleOrDefaultAsync(condition);
            return entity;
        }

        public IQueryable<T> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();

            query = query.Where(condition);
            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
