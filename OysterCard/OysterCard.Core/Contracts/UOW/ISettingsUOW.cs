using OysterCard.Core.Contracts.Repositories;

namespace OysterCard.Core.Contracts.UOW
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="Settings"/> unit of work.
    /// </summary>
    public interface ISettingsUOW : IUOW
    {
        ISettingsRepository Settings { get; }
    }
}
