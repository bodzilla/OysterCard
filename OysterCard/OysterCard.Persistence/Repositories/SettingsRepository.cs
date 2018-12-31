using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Models;

namespace OysterCard.Persistence.Repositories
{
    /// <inheritdoc cref="ISettingsRepository" />
    public sealed class SettingsRepository : GenericRepository<Settings>, ISettingsRepository
    {
        /// <summary>
        /// Gets the base context.
        /// </summary>
        public DbContext DbContext => Context;

        /// <inheritdoc />
        public SettingsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
