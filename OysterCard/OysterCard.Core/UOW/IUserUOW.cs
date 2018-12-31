using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Models;

namespace OysterCard.Core.UOW
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="User"/> unit of work.
    /// </summary>
    public interface IUserUOW : IUOW
    {
        IUserRepository Users { get; }
    }
}
