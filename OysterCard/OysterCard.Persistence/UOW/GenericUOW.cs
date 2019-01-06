using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.UOW;

namespace OysterCard.Persistence.UOW
{
    /// <inheritdoc />
    public class GenericUOW : IUOW
    {
        private readonly DbContext _context;

        #region Default Constructor

        /// <inheritdoc />
        public GenericUOW(DbContext context) => _context = context;

        #endregion

        /// <inheritdoc />
        public void Dispose() => _context.Dispose();

        /// <inheritdoc />
        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        /// <inheritdoc />
        public void Complete() => _context.SaveChanges();
    }
}
