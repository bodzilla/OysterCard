using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.DTO;
using OysterCard.Core.Models;
using OysterCard.Core.UOW;

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserUOW _unitOfWork;

        /// <inheritdoc />
        public UserService(IUserUOW unitOfWork) => _unitOfWork = unitOfWork;

        /// <inheritdoc />
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return users.Select(Mapper.Map<User, UserDTO>);
        }

        /// <inheritdoc />
        public async Task<UserDTO> GetByUsernameAsync(string username)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.NormalizedUserName.Equals(username.ToUpper()));
            return Mapper.Map<UserDTO>(user);
        }
    }
}
