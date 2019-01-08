using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
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
        #region Private Members

        private readonly IOysterUOW _unitOfWork;
        private readonly ISettingsService _settingsService;

        private bool _ageLimitsSet;
        private int _lowerAgeLimitJunior;
        private int _upperAgeLimitJunior;
        private int _lowerAgeLimitAdult;
        private int _upperAgeLimitAdult;

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public OysterService(IOysterUOW unitOfWork, ISettingsService settingsService)
        {
            _unitOfWork = unitOfWork;
            _settingsService = settingsService;
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
                oysterVm.OysterType = await SetOysterType(oysterVm);

                await _unitOfWork.Oysters.AddAsync(Mapper.Map<Oyster>(oysterVm));
            }
            await _unitOfWork.CompleteAsync();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the <see cref="OysterType"/> based on <see cref="OysterApplicationVM.DateOfBirth"/>.
        /// </summary>
        /// <param name="oysterVm"></param>
        /// <returns></returns>
        private async Task<OysterType> SetOysterType(OysterApplicationVM oysterVm)
        {
            await SetOysterAgeLimits();
            int age = GetAge(oysterVm.DateOfBirth);

            // Assess qualification.
            if (age < 0) throw new ArgumentException($"Age ({age}) is not valid.");
            if (age >= _lowerAgeLimitJunior && age <= _upperAgeLimitJunior) return OysterType.Junior;
            if (age >= _lowerAgeLimitAdult && age <= _upperAgeLimitAdult) return OysterType.Adult;
            return OysterType.Senior;
        }

        /// <summary>
        /// Calculate the age based on date passed in.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        private static int GetAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - dateOfBirth.Year;

            // If we haven't reached the birth month and day yet, -1 from age.
            if (today.Month < dateOfBirth.Month || today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day) age--;
            return age;
        }

        /// <summary>
        /// Sets all the oyster age limits from settings.
        /// </summary>
        /// <returns></returns>
        private async Task SetOysterAgeLimits()
        {
            if (_ageLimitsSet) return;
            var settings = await _settingsService.GetOysterTypeAgeLimitsAsync();
            var ageLimits = settings.ToList();
            _lowerAgeLimitJunior = int.Parse(ageLimits.First(x => x.Key.Equals("LowerAgeLimitJunior")).Value);
            _upperAgeLimitJunior = int.Parse(ageLimits.First(x => x.Key.Equals("UpperAgeLimitJunior")).Value);
            _lowerAgeLimitAdult = int.Parse(ageLimits.First(x => x.Key.Equals("LowerAgeLimitAdult")).Value);
            _upperAgeLimitAdult = int.Parse(ageLimits.First(x => x.Key.Equals("UpperAgeLimitAdult")).Value);
            _ageLimitsSet = true;
        }

        #endregion
    }
}
