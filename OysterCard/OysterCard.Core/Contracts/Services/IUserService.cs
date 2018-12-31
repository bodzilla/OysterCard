using System.Collections.Generic;
using System.Threading.Tasks;
using OysterCard.Core.DTO;
using OysterCard.Core.Models;

namespace OysterCard.Core.Contracts.Services
{
    /// <summary>
    /// The <see cref="User"/> serivce.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all <see cref="UserDTO"/>.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDTO>> GetAllAsync();

        /// <summary>
        /// Gets <see cref="UserDTO"/> by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserDTO> GetByEmailAsync(string email);
    }
}
