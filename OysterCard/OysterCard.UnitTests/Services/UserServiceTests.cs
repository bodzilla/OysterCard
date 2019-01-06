using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.Mappings;
using OysterCard.Core.Models;
using OysterCard.Core.Services;

namespace OysterCard.UnitTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserUOW> _unitOfWork;
        private UserService _service;

        [SetUp]
        public void Setup()
        {
            // First, set up all the mappings.
            MappingConfiguration.Configure();

            // Assign a mocked unit of work to the user service.
            _unitOfWork = new Mock<IUserUOW>();
            _service = new UserService(_unitOfWork.Object);
        }

        [Test]
        public async Task GetAllAsync_GetAllUserDtoAsync_ReturnsThreeUserDto()
        {
            // Set up sample data.
            var data = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "test1@test.com"
                },
                new User
                {
                    Id = 2,
                    Email = "test2@test.com"
                },
                new User
                {
                    Id = 3,
                    Email = "test3@test.com"
                }
            };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Users.GetAllAsync()).ReturnsAsync(data);

            var result = await _service.GetAllAsync();
            Assert.That(result.Count(), Is.EqualTo(3));
        }
    }
}
