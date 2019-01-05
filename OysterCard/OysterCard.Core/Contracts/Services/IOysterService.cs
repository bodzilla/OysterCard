using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        /// Gets all <see cref="Oyster"/>.
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<Oyster>> GetAllAsync(params Expression<Func<Oyster, object>>[] navigationProperties);

        /// <summary>
        /// Creates <see cref="Oyster"/>s with verified state as false.
        /// </summary>
        /// <param name="oysters"></param>
        /// <returns></returns>
        Task ApplyForOysters(params OysterApplicationVM[] oysters);
    }
}
