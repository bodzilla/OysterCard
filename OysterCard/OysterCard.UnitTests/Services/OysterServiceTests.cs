using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OysterCard.Core.Contracts.Common;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.DTO;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;
using OysterCard.Core.Services;
using OysterCard.Core.ViewModels;

namespace OysterCard.UnitTests.Services
{
    [TestFixture]
    public class OysterServiceTests
    {
        private Mock<IOysterUOW> _unitOfWork;
        private Mock<ISettingsService> _settingsService;
        private Mock<IUtilities> _utilities;
        private IOysterService _service;

        [SetUp]
        public void Setup()
        {
            // First, set up all the mappings.
            ServicesInitializer.ConfigureMappings();

            // Assign mocked objects to the oyster service.
            _unitOfWork = new Mock<IOysterUOW>();
            _settingsService = new Mock<ISettingsService>();
            _utilities = new Mock<IUtilities>();
            _service = new OysterService(_unitOfWork.Object, _settingsService.Object, _utilities.Object);
        }

        [Test]
        public async Task GetAllAsync_GetAllOysterDtoAsync_ReturnsThreeOysterDto()
        {
            // Set up sample data.
            var data = new List<Oyster>
            {
                new OysterAdult { Id = 1, Forename = "Test1" },
                new OysterJunior { Id = 2, Forename = "Test2" },
                new OysterSenior { Id = 3, Forename = "Test3" }
            };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAllAsync()).ReturnsAsync(data);

            var result = await _service.GetAllAsync();

            // Cast to list to make assertions.
            var oysters = result as IList<OysterDTO> ?? result.ToList();

            Assert.That(oysters, Is.TypeOf<List<OysterDTO>>());
            Assert.That(oysters.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetListAsync_GetListOfOysterDtoAsync_ReturnsThreeOysterDto()
        {
            // Set up sample data.
            var data = new List<Oyster>
            {
                new OysterAdult { Id = 1, Forename = "Test1" },
                new OysterJunior { Id = 2, Forename = "Test2" },
                new OysterSenior { Id = 3, Forename = "Test3" }
            };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetListAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetListAsync(x => x.EntityActive);

            // Cast to list to make assertions.
            var oysters = result as IList<OysterDTO> ?? result.ToList();

            Assert.That(oysters, Is.TypeOf<List<OysterDTO>>());
            Assert.That(oysters.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetAsync_GetOysterDtoJuniorAsync_ReturnsOysterDtoJunior()
        {
            // Set up sample data.
            var data = new OysterJunior { Id = 1, Forename = "Test1" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.EqualTo(OysterType.Junior));
        }

        [Test]
        public async Task GetAsync_GetOysterDtoAdultAsync_ReturnsOysterDtoAdult()
        {
            // Set up sample data.
            var data = new OysterAdult { Id = 1, Forename = "Test1" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.EqualTo(OysterType.Adult));
        }

        [Test]
        public async Task GetAsync_GetOysterDtoSeniorAsync_ReturnsOysterDtoSenior()
        {
            // Set up sample data.
            var data = new OysterSenior { Id = 1, Forename = "Test1" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.EqualTo(OysterType.Senior));
        }

        [Test]
        public async Task GetAsync_GetOysterDtoJuniorAsync_ReturnsOysterDtoAsWrongOysterType()
        {
            // Set up sample data.
            var data = new OysterAdult { Id = 1, Forename = "Test1" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.Not.EqualTo(OysterType.Junior));
        }

        [Test]
        public async Task GetAsync_GetOysterDtoAdultAsync_ReturnsOysterDtoAsWrongOysterType()
        {
            // Set up sample data.
            var data = new OysterSenior { Id = 1, Forename = "Test1" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.Not.EqualTo(OysterType.Adult));
        }

        [Test]
        public async Task GetAsync_GetOysterDtoSeniorAsync_ReturnsOysterDtoAsWrongOysterType()
        {
            // Set up sample data.
            var data = new OysterJunior { Id = 1, Forename = "Test1" };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.Not.EqualTo(OysterType.Senior));
        }

        [Test]
        public void CreateNonVerifiedAsync_CreateOysterAsync_DoesNotThrowAsync()
        {
            // Set up sample data.
            var settings = new Dictionary<string, string>
            {
                {"LowerAgeLimitJunior","0"},
                {"UpperAgeLimitJunior","15"},
                {"LowerAgeLimitAdult","16"},
                {"UpperAgeLimitAdult","74"}
            };

            var data = new OysterApplicationVM { UserId = 1, Forename = "Test1" };

            // Ensure these methods return the sample data / completed task.
            _settingsService.Setup(x => x.GetOysterTypeAgeLimitsAsync()).ReturnsAsync(settings);
            _unitOfWork.Setup(x => x.Oysters.AddAsync(It.IsAny<Oyster[]>())).Returns(Task.CompletedTask);
            _unitOfWork.Setup(x => x.CompleteAsync()).Returns(Task.CompletedTask);

            Assert.DoesNotThrowAsync(() => _service.CreateNonVerifiedAsync(data));
        }

        /// <summary>
        /// </summary>
        /// <param name="age"></param>
        /// <param name="initType">The type to set the sample data to.
        /// Ensuring that if the method fails, it doesn't accidently default to the correct type, and thus wrongfully passing the test.</param>
        /// <param name="actualType">The actual expected type to be returned.</param>
        /// <returns></returns>
        [TestCase(10, OysterType.Senior, OysterType.Junior)]
        [TestCase(50, OysterType.Junior, OysterType.Adult)]
        [TestCase(100, OysterType.Adult, OysterType.Senior)]
        public async Task SetOysterTypeAsync_CheckIfCorrectOysterTypeIsReturned_ReturnsCorrectOysterType(int age, OysterType initType, OysterType actualType)
        {
            // Set up sample data.
            var settings = new Dictionary<string, string>
            {
                {"LowerAgeLimitJunior","0"},
                {"UpperAgeLimitJunior","15"},
                {"LowerAgeLimitAdult","16"},
                {"UpperAgeLimitAdult","74"}
            };

            var data = new OysterApplicationVM { OysterType = initType };

            // Ensure these methods return the sample data.
            _settingsService.Setup(x => x.GetOysterTypeAgeLimitsAsync()).ReturnsAsync(settings);
            _utilities.Setup(x => x.GetAge(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(age);

            var result = await _service.GetOysterTypeAsync(data);
            Assert.That(result, Is.EqualTo(actualType));
        }
    }
}
