using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsUOW _unitOfWork;

        /// <inheritdoc />
        public SettingsService(ISettingsUOW unitOfWork) => _unitOfWork = unitOfWork;

        /// <inheritdoc />
        public async Task<IDictionary<string, string>> GetAllAsync()
        {
            var settings = await _unitOfWork.Settings.GetAllAsync();
            return settings.ToDictionary(setting => setting.Key, setting => setting.Value);
        }

        /// <inheritdoc />
        public async Task<IDictionary<string, string>> GetOysterTypeAgeLimitsAsync()
        {
            var settings = await _unitOfWork.Settings.GetListAsync(x => x.Key.Contains("AgeLimit"));
            return settings.ToDictionary(setting => setting.Key, setting => setting.Value);
        }
    }
}
