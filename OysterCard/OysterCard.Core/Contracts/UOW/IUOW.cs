using System;
using System.Threading.Tasks;

namespace OysterCard.Core.Contracts.UOW
{
    /// <inheritdoc />
    /// <summary>
    /// The base unit of work interface where all units of work inherit from.
    /// </summary>
    public interface IUOW : IDisposable
    {
        /// <summary>
        /// Persist changes to the database.
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();

        /// <summary>
        /// Persist changes to the database.
        /// </summary>
        /// <returns></returns>
        void Complete();
    }
}
