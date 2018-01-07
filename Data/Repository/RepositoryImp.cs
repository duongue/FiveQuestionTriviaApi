using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryImp<T> : IRepository<T> where T : class
    {
        public RepositoryImp(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.DbContext = context;
            this.DbSet = this.DbContext.Set<T>();
        }

        protected DbContext DbContext { get; }
        protected DbSet<T> DbSet { get; }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            if (entity == null)
            {
                return;
            }
            this.Delete(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this.DbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach(var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this.DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public Task<T> GetByIdAsync(object id)
        {
            return this.DbSet.FindAsync(id);
        }

        public int SaveChanges()
        {
            return this.DbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsyn()
        {
            return await this.DbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        }

        public void UpdateValues(T oldEntity, T newEntity)
        {
            if (oldEntity != null)
            {
                this.DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                this.DbContext.SaveChanges();
            }
        }
    }
}
