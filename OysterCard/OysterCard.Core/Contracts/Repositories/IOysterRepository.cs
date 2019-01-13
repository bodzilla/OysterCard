using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;

namespace OysterCard.Core.Contracts.Repositories
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="Oyster"/> repository.
    /// </summary>
    public interface IOysterRepository : IRepository<Oyster>
    {
        /// <summary>
        /// Get <see cref="Oyster"/> by id.
        /// </summary>
        /// <param name="oysterId"></param>
        /// <returns></returns>
        Task<Oyster> GetAsync(int oysterId);

        /// <summary>
        /// Gets <see cref="User"/>s active and approved <see cref="Oyster"/>s.
        /// </summary>
        /// <param name="userId"></param>
        Task<IEnumerable<Oyster>> GetActiveAndApprovedOystersAsync(int userId);

        /// <summary>
        /// Gets <see cref="User"/>s active and non-approved <see cref="Oyster"/>s.
        /// </summary>
        /// <param name="userId"></param>
        Task<IEnumerable<Oyster>> GetActiveAndNonApprovedOystersAsync(int userId);

        /// <summary>
        /// Set the <see cref="OysterState"/>.
        /// </summary>
        /// <param name="oysterId"></param>
        /// <param name="oysterState"></param>
        /// <returns></returns>
        Task UpdateOysterStateAsync(int oysterId, OysterState oysterState);
    }
}
