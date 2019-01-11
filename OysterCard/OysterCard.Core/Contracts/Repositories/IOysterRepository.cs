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
        /// Set the <see cref="OysterState"/>.
        /// </summary>
        /// <param name="oysterId"></param>
        /// <param name="oysterState"></param>
        /// <returns></returns>
        Task UpdateOysterStateAsync(int oysterId, OysterState oysterState);
    }
}
