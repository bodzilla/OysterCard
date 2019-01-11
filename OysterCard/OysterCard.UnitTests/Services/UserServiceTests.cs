using Moq;
using NUnit.Framework;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.Services;

namespace OysterCard.UnitTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserUOW> _unitOfWork;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            // First, set up all the mappings.
            ServicesInitializer.ConfigureMappings();

            // Assign a mocked unit of work to the user service.
            _unitOfWork = new Mock<IUserUOW>();
            _userService = new UserService(_unitOfWork.Object);
        }
    }
}
