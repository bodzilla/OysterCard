﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.Models;

namespace OysterCard.Core.Contracts.Services
{
    /// <summary>
    /// The <see cref="Settings"/> serivce.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets all <see cref="Settings"/>.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Settings>> GetAllAsync();
    }
}
