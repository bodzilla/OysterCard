using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Models;
using OysterCard.Core.UOW;

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class OysterService : IOysterService
    {
        private readonly IOysterUOW _unitOfWork;

        /// <inheritdoc />
        public OysterService(IOysterUOW unitOfWork) => _unitOfWork = unitOfWork;

        /// <inheritdoc />
        public async Task<IEnumerable<Oyster>> GetAllAsync() => await _unitOfWork.Oysters.GetAllAsync();
    }
}
