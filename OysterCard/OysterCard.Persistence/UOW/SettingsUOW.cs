using Microsoft.EntityFrameworkCore;
using OysterCard.Core.Contracts.Repositories;
using OysterCard.Core.UOW;
using OysterCard.Persistence.Repositories;

namespace OysterCard.Persistence.UOW
{
    /// <inheritdoc cref="ISettingsUOW" />
    public sealed class SettingsUOW : GenericUOW, ISettingsUOW
    {
        /// <inheritdoc />
        public SettingsUOW(DbContext context) : base(context) => Settings = new SettingsRepository(context);

        /// <inheritdoc />
        public ISettingsRepository Settings { get; }
    }
}
