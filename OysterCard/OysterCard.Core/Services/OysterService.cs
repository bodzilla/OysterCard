using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.DTO;
using OysterCard.Core.Models;
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
        public async Task<IEnumerable<OysterDTO>> GetAllAsync(params Expression<Func<Oyster, object>>[] navigationProperties)
        {
            var oysters = await _unitOfWork.Oysters.GetAllAsync(navigationProperties);
            return oysters.Select(Mapper.Map<Oyster, OysterDTO>);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<OysterDTO>> GetListAsync(Expression<Func<Oyster, bool>> where, params Expression<Func<Oyster, object>>[] navigationProperties)
        {
            var oysters = await _unitOfWork.Oysters.GetListAsync(where, navigationProperties);
            return oysters.Select(Mapper.Map<Oyster, OysterDTO>);
        }

        /// <inheritdoc />
        public async Task<OysterDTO> GetAsync(Expression<Func<Oyster, bool>> where, params Expression<Func<Oyster, object>>[] navigationProperties)
        {
            var oyster = await _unitOfWork.Oysters.GetAsync(where, navigationProperties);
            return Mapper.Map<OysterDTO>(oyster);
        }

        /// <inheritdoc />
        public async Task CreateNonVerifiedAsync(params OysterApplicationVM[] oystersVm)
        {
            foreach (var oysterVm in oystersVm) await _unitOfWork.Oysters.AddAsync(Mapper.Map<Oyster>(oysterVm));
            await _unitOfWork.CompleteAsync();
        }
    }
}
