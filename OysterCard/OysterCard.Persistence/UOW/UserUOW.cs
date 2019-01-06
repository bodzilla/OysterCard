using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Persistence.Repositories;

namespace OysterCard.Persistence.UOW
{
    /// <inheritdoc cref="IUserUOW" />
    public sealed class UserUOW : GenericUOW, IUserUOW
    {
        /// <inheritdoc />
        public UserUOW(DbContext context) : base(context) => Users = new UserRepository(context);

        /// <inheritdoc />
        public IUserRepository Users { get; }
    }
}
