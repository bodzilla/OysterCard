using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;

namespace OysterCard.Core.Contracts.Repositories
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="Settings"/> repository.
    /// </summary>
    public interface ISettingsRepository : IRepository<Settings>
    {
        /// <summary>
        /// Gets <see cref="OysterType"/> age limits.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Settings>> GetOysterTypeAgeLimitsAsync();
    }
}
