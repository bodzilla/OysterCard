using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.UOW;
using OysterCard.Persistence.Repositories;

namespace OysterCard.Persistence.UOW
{
    /// <inheritdoc cref="IUserUOW" />
    public sealed class OysterUOW : GenericUOW, IOysterUOW
    {
        /// <inheritdoc />
        public OysterUOW(DbContext context) : base(context) => Oysters = new OysterRepository(context);

        /// <inheritdoc />
        public IOysterRepository Oysters { get; }
    }
}
