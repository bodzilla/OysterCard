using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.DTO;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;

namespace OysterCard.Core.Contracts.Services
{
    /// <summary>
    /// The <see cref="Oyster"/> serivce.
    /// </summary>
    public interface IOysterService
    {
        /// <summary>
        /// Gets all <see cref="Oyster"/>s.
        /// </summary>
        Task<IEnumerable<OysterDTO>> GetAllAsync();

        /// <summary>
        /// Gets <see cref="User"/>s active and approved <see cref="Oyster"/>s.
        /// </summary>
        /// <param name="userId"></param>
        Task<IEnumerable<OysterDTO>> GetActiveAndApprovedAsync(int userId);

        /// <summary>
        /// Gets <see cref="User"/>s active and non-approved <see cref="Oyster"/>s.
        /// </summary>
        /// <param name="userId"></param>
        Task<IEnumerable<OysterDTO>> GetActiveAndNonApprovedAsync(int userId);

        /// <summary>
        /// Creates <see cref="Oyster"/>s with verified state as false.
        /// Sets the <see cref="OysterType"/> based on applicant's date of brith.
        /// </summary>
        /// <param name="oystersVm"></param>
        /// <returns></returns>
        Task CreateNonVerifiedAsync(params OysterApplicationVM[] oystersVm);

        /// <summary>
        /// Sets the <see cref="OysterType"/> based on <see cref="OysterApplicationVM.DateOfBirth"/>.
        /// </summary>
        /// <param name="oysterVm"></param>
        /// <returns></returns>
        Task<OysterType> GetOysterTypeAsync(OysterApplicationVM oysterVm);

        /// <summary>
        /// Set the <see cref="OysterState"/>.
        /// </summary>
        /// <param name="oysterId"></param>
        /// <param name="oysterState"></param>
        /// <returns></returns>
        Task UpdateOysterStateAsync(int oysterId, OysterState oysterState);
    }
}
