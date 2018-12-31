using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<UserDTO>> GetAllAsync(params Expression<Func<User, object>>[] navigationProperties);

        /// <summary>
        /// Gets <see cref="UserDTO"/> by email.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        Task<UserDTO> GetByEmailAsync(string email, params Expression<Func<User, object>>[] navigationProperties);
    }
}
