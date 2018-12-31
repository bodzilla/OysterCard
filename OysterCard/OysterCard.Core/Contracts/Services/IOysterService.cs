using System.Collections.Generic;
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
        /// <returns></returns>
        Task<IEnumerable<Oyster>> GetAllAsync();
    }
}
