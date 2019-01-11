using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;

namespace OysterCard.Core.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserUOW _unitOfWork;

        /// <inheritdoc />
        public UserService(IUserUOW unitOfWork) => _unitOfWork = unitOfWork;
    }
}
