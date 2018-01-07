using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        void Add(T entity);

        void Update(T entity);

        void UpdateValues(T oldEntity, T newEntity);

        void Delete(T entity);

        void Delete(int id);

        int SaveChanges();

        Task<int> SaveChangesAsyn();
    }
}
