using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;

namespace OysterCard.Persistence.Repositories
{
    /// <inheritdoc cref="IOysterRepository" />
    public sealed class OysterRepository : GenericRepository<Oyster>, IOysterRepository
    {
        /// <summary>
        /// Gets the base context.
        /// </summary>
        public DbContext DbContext => Context;

        /// <inheritdoc />
        public OysterRepository(DbContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public async Task UpdateOysterStateAsync(int oysterId, OysterState oysterState)
        {
            var oyster = await Context.FindAsync<Oyster>(oysterId);
            oyster.OysterState = oysterState;
        }
    }
}
