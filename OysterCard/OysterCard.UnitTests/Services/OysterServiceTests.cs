using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.DTO;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;
using OysterCard.Core.Services;

namespace OysterCard.UnitTests.Services
{
    [TestFixture]
    public class OysterServiceTests
    {
        private Mock<IOysterUOW> _unitOfWork;
        private OysterService _service;

        [SetUp]
        public void Setup()
        {
            // First, set up all the mappings.
            ServicesInitializer.ConfigureMappings();

            // Assign a mocked unit of work to the oyster service.
            _unitOfWork = new Mock<IOysterUOW>();
            _service = new OysterService(_unitOfWork.Object);
        }

        [Test]
        public async Task GetAllAsync_GetAllOysterDtoAsync_ReturnsThreeOysterDto()
        {
            // Set up sample data.
            var data = new List<Oyster>
            { new OysterAdult { Id = 1, Forename = "Test1" }, new OysterJunior { Id = 2, Forename = "Test2" }, new OysterSenior { Id = 3, Forename = "Test3" } };

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
            { new OysterAdult { Id = 1, Forename = "Test1" }, new OysterJunior { Id = 2, Forename = "Test2" }, new OysterSenior { Id = 3, Forename = "Test3" } };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Oysters.GetListAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

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
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

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
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

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
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

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
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

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
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

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
            _unitOfWork.Setup(x => x.Oysters.GetAsync(It.IsAny<Expression<Func<Oyster, bool>>>(), It.IsAny<Expression<Func<Oyster, object>>[]>())).ReturnsAsync(data);

            var result = await _service.GetAsync(x => x.EntityActive);

            Assert.That(result, Is.TypeOf<OysterDTO>());
            Assert.That(result.OysterType, Is.Not.EqualTo(OysterType.Senior));
        }
    }
}
