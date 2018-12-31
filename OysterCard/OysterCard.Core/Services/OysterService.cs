using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        /// <param name="navigationProperties"></param>
        /// <inheritdoc />
        public async Task<IEnumerable<Oyster>> GetAllAsync(params Expression<Func<Oyster, object>>[] navigationProperties) =>
            await _unitOfWork.Oysters.GetAllAsync(navigationProperties);
    }
}
