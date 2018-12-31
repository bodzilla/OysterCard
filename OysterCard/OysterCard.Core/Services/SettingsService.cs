using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Models;
using OysterCard.Core.UOW;

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsUOW _unitOfWork;

        /// <inheritdoc />
        public SettingsService(ISettingsUOW unitOfWork) => _unitOfWork = unitOfWork;

        /// <inheritdoc />
        public async Task<IEnumerable<Settings>> GetAllAsync() => await _unitOfWork.Settings.GetAllAsync();
    }
}
