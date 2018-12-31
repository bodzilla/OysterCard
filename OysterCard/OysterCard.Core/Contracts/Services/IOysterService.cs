using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OysterCard.Core.Models;

namespace OysterCard.Core.Contracts.Services
{
    /// <summary>
    /// The <see cref="Oyster"/> serivce.
    /// </summary>
    public interface IOysterService
    {
        /// <summary>
        /// Gets all <see cref="Oyster"/>.
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<Oyster>> GetAllAsync(params Expression<Func<Oyster, object>>[] navigationProperties);
    }
}
