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

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserUOW _unitOfWork;

        /// <inheritdoc />
        public UserService(IUserUOW unitOfWork) => _unitOfWork = unitOfWork;

        /// <inheritdoc />
        public async Task<IEnumerable<UserDTO>> GetAllAsync(params Expression<Func<User, object>>[] navigationProperties)
        {
            var users = await _unitOfWork.Users.GetAllAsync(navigationProperties);
            return users.Select(Mapper.Map<User, UserDTO>);
        }

        /// <inheritdoc />
        public async Task<UserDTO> GetByIdAsync(int id, params Expression<Func<User, object>>[] navigationProperties)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == id, navigationProperties);
            return Mapper.Map<UserDTO>(user);
        }

        /// <inheritdoc />
        public async Task<UserDTO> GetByEmailAsync(string email, params Expression<Func<User, object>>[] navigationProperties)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.NormalizedEmail.Equals(email.ToUpper()), navigationProperties);
            return Mapper.Map<UserDTO>(user);
        }
    }
}
