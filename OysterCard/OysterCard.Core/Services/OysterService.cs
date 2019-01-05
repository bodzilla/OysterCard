using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Models;
using OysterCard.Core.UOW;
using OysterCard.Core.ViewModels;

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

        /// <inheritdoc />
        public async Task ApplyForOysters(params OysterApplicationVM[] oystersVm)
        {
            foreach (var oysterVm in oystersVm)
            {
                var oyster = Mapper.Map<Oyster>(oysterVm);
                await _unitOfWork.Oysters.AddAsync(oyster);
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
