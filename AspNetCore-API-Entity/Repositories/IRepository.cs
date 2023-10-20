using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Entity.Repositories
{
    public interface IRepository <T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);

        Task<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);
    }
}
