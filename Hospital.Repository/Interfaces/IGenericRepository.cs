using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IGenericRepository<T>:IDisposable
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> filter=null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null,
            string includeProperties="");

        T GetById(Object id);
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
