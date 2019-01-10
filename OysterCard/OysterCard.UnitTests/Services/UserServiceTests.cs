using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.DTO;
using OysterCard.Core.Models;
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

        [Test]
        public async Task GetAllAsync_GetAllUserDtoAsync_ReturnsThreeUserDto()
        {
            // Set up sample data.
            var data = new List<User>
            {
                new User { Id = 1, Email = "test1@test.com" },
                new User { Id = 2, Email = "test2@test.com" },
                new User { Id = 3, Email = "test3@test.com" }
            };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Users.GetAllAsync()).ReturnsAsync(data);

            var result = await _userService.GetAllAsync();

            // Cast to list to make assertions.
            var users = result as IList<UserDTO> ?? result.ToList();

            Assert.That(users, Is.TypeOf<List<UserDTO>>());
            Assert.That(users.Count, Is.EqualTo(3));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(int.MaxValue)]
        public async Task GetByIdAsync_GetUserDtoByIdAsync_ReturnsUserDto(int id)
        {
            // Set up sample data.
            var data = new User { Id = id, Email = "test1@test.com" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Users.GetAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(data);

            var result = await _userService.GetByIdAsync(id);
            Assert.That(result, Is.TypeOf<UserDTO>());
        }

        [TestCase("test@test.com")]
        [TestCase("example@example.net")]
        [TestCase("email@email.co.uk")]
        public async Task GetByEmailAsync_GetUserDtoByEmailAsync_ReturnsUserDto(string email)
        {
            // Set up sample data.
            var data = new User { Id = 1, Email = email };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Users.GetAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(data);

            var result = await _userService.GetByEmailAsync(email);
            Assert.That(result, Is.TypeOf<UserDTO>());
        }
    }
}
