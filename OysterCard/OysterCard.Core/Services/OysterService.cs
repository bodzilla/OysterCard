using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using OysterCard.Core.Contracts.Common;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.DTO;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class OysterService : IOysterService
    {
        private readonly IOysterUOW _unitOfWork;
        private readonly ISettingsService _settingsService;
        private readonly IUtilities _utilities;

        /// <inheritdoc />
        public OysterService(IOysterUOW unitOfWork, ISettingsService settingsService, IUtilities utilities)
        {
            _unitOfWork = unitOfWork;
            _settingsService = settingsService;
            _utilities = utilities;
        }

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
            foreach (var oysterVm in oystersVm)
            {
                // Assess what oyster type the applicant qualifies for.
                oysterVm.OysterType = await GetOysterTypeAsync(oysterVm);

                // We don't need to set the oyster state as the default value is: in review.
                // So we can go ahead and create.
                await _unitOfWork.Oysters.AddAsync(Mapper.Map<Oyster>(oysterVm));
            }
            await _unitOfWork.CompleteAsync();
        }

        /// <inheritdoc />
        public async Task<OysterType> GetOysterTypeAsync(OysterApplicationVM oysterVm)
        {
            int age = _utilities.GetAge(oysterVm.DateOfBirth);
            var settings = await _settingsService.GetOysterTypeAgeLimitsAsync();

            // Lower age limits.
            int lowerAgeLimitJunior = int.Parse(settings["LowerAgeLimitJunior"]);
            int lowerAgeLimitAdult = int.Parse(settings["LowerAgeLimitAdult"]);

            // Upper age limits.
            int upperAgeLimitJunior = int.Parse(settings["UpperAgeLimitJunior"]);
            int upperAgeLimitAdult = int.Parse(settings["UpperAgeLimitAdult"]);

            // Assess qualification.
            if (age < 0) throw new ArgumentException($"Age ({age}) is not valid.");
            if (age >= lowerAgeLimitJunior && age <= upperAgeLimitJunior) return OysterType.Junior;
            if (age >= lowerAgeLimitAdult && age <= upperAgeLimitAdult) return OysterType.Adult;
            return OysterType.Senior;
        }

        /// <inheritdoc />
        public async Task UpdateOysterStateAsync(int oysterId, OysterState oysterState)
        {
            var oyster = await _unitOfWork.Oysters.GetAsync(x => x.Id == oysterId);
            oyster.OysterState = oysterState;
            await _unitOfWork.CompleteAsync();
        }
    }
}
