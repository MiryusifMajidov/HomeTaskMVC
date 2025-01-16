using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalApojectTest4.Dal.Repositories
{
    public interface IRepsitory<T> where T : class
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id, bool isTracking, params string[] includes);
        Task<T?> GetSingleByConditionAsync(Expression<Func<T, bool>> condition);
        IQueryable<T> GetAllByConditionAsync(Expression<Func<T, bool>> condition);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> SaveChangeAsync();

    }
}
