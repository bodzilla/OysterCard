using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OysterCard.Core.Contracts.Repositories
{
    /// <summary>
    /// The repository for CRUD operations using <see cref="IEntity"/>.
    /// </summary>
    /// <typeparam name="T">The <see cref="IEntity" /> type.</typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        #region Asynchronous Methods

        /// <summary>
        /// Adds <see cref="T"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddAsync(params T[] entities);

        /// <summary>
        /// Checks if <see cref="T"/> exists.
        /// </summary>
        /// <param name="where"></param>
        /// <returns><see cref="bool"/></returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// Gets a single <see cref="T"/> with given navigation properties.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns><see cref="T"/></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets all <see cref="T"/> with given navigation properties.
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns>List of <see cref="T"/></returns>
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets specific <see cref="T"/> with given navigation properties.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns>List of <see cref="T"/></returns>
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        #endregion

        #region Synchronous Methods

        /// <summary>
        /// Adds <see cref="T"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void Add(params T[] entities);

        /// <summary>
        /// Checks if <see cref="T"/> exists.
        /// </summary>
        /// <param name="where"></param>
        /// <returns><see cref="bool"/></returns>
        bool Exists(Expression<Func<T, bool>> where);

        /// <summary>
        /// Gets a single <see cref="T"/> with given navigation properties.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns><see cref="T"/></returns>
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets all <see cref="T"/> with given navigation properties.
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns>List of <see cref="T"/></returns>
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets specific <see cref="T"/> with given navigation properties.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns>List of <see cref="T"/></returns>
        IEnumerable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        #endregion

        #region Universal Methods

        /// <summary>
        /// Removes <see cref="T"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void Remove(params T[] entities);

        /// <summary>
        /// Sets <see cref="T"/> as inactive.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void SetInactive(params T[] entities);

        #endregion
    }
}
