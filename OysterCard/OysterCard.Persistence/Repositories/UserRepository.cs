using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Models;

namespace OysterCard.Persistence.Repositories
{
    /// <inheritdoc cref="IUserRepository" />
    public sealed class UserRepository : GenericRepository<User>, IUserRepository
    {
        /// <summary>
        /// Gets the base context.
        /// </summary>
        public DbContext DbContext => Context;

        /// <inheritdoc />
        public UserRepository(DbContext context)
            : base(context)
        {
        }
    }
}
