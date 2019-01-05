using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts;
using OysterCard.Core.Contracts.Repositories;

namespace OysterCard.Persistence.Repositories
{
    /// <inheritdoc />
    /// <summary>
    /// A generic repository where all data related actions are executed.
    /// </summary>
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext Context;

        #region Default Constructor

        /// <inheritdoc />
        public GenericRepository(DbContext context) => Context = context;

        #endregion

        #region Asynchronous Methods

        /// <inheritdoc />
        public virtual async Task AddAsync(params T[] entities)
        {
            foreach (T entity in entities)
            {
                entity.EntityCreated = DateTime.Now;
                await Context.Set<T>().AddAsync(entity);
            }
        }

        /// <inheritdoc />
        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> where) => await GetAsync(where) != null;

        /// <inheritdoc />
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            T entity = await query.FirstOrDefaultAsync(where);
            return entity;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            IEnumerable<T> entities = await query.ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            IEnumerable<T> entities = await query.Where(where).ToListAsync();
            return entities;
        }

        #endregion

        #region Synchronous Methods

        /// <inheritdoc />
        public virtual void Add(params T[] entities)
        {
            foreach (T entity in entities)
            {
                entity.EntityCreated = DateTime.Now;
                Context.Set<T>().Add(entity);
            }
        }

        /// <inheritdoc />
        public virtual bool Exists(Expression<Func<T, bool>> where) => Get(where) != null;

        /// <inheritdoc />
        public virtual T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            T entity = query.FirstOrDefault(where);
            return entity;
        }

        /// <inheritdoc />
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            IEnumerable<T> entities = query.ToList();
            return entities;
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = navigationProperties.Aggregate(query, (current, navigationProperty) => current.Include(navigationProperty));
            IEnumerable<T> entities = query.Where(where).ToList();
            return entities;
        }

        #endregion

        #region Universal Methods

        /// <inheritdoc />
        public virtual void Remove(params T[] entities)
        {
            foreach (T entity in entities) Context.Set<T>().Remove(entity);
        }

        /// <inheritdoc />
        public virtual void SetInactive(params T[] entities)
        {
            foreach (T entity in entities) entity.EntityActive = false;
        }

        #endregion
    }
}
