using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OysterCard.Core.DTO;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;

namespace OysterCard.Core.Contracts.Services
{
    /// <summary>
    /// The <see cref="Oyster"/> serivce.
    /// </summary>
    public interface IOysterService
    {
        /// <summary>
        /// Gets all <see cref="OysterDTO"/>.
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<OysterDTO>> GetAllAsync(params Expression<Func<Oyster, object>>[] navigationProperties);

        /// <summary>
        /// Get list of <see cref="OysterDTO"/> with where condition.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<OysterDTO>> GetListAsync(Expression<Func<Oyster, bool>> where, params Expression<Func<Oyster, object>>[] navigationProperties);

        /// <summary>
        /// Get <see cref="OysterDTO"/> with where condition.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<OysterDTO> GetAsync(Expression<Func<Oyster, bool>> where, params Expression<Func<Oyster, object>>[] navigationProperties);

        /// <summary>
        /// Creates <see cref="Oyster"/>s with verified state as false.
        /// Sets the <see cref="OysterType"/> based on applicant's date of brith.
        /// </summary>
        /// <param name="oysters"></param>
        /// <returns></returns>
        Task CreateNonVerifiedAsync(params OysterApplicationVM[] oysters);
    }
}
