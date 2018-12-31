using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.Models;

namespace OysterCard.Core.UOW
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="Oyster"/> unit of work.
    /// </summary>
    public interface IOysterUOW : IUOW
    {
        IOysterRepository Oysters { get; }
    }
}
