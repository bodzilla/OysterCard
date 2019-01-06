using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.Models;
using OysterCard.Core.Services;

namespace OysterCard.UnitTests.Services
{
    [TestFixture]
    public class SettingsServiceTests
    {
        private Mock<ISettingsUOW> _unitOfWork;
        private SettingsService _service;

        [SetUp]
        public void Setup()
        {
            // First, set up all the mappings.
            ServicesInitializer.ConfigureMappings();

            // Assign a mocked unit of work to the settings service.
            _unitOfWork = new Mock<ISettingsUOW>();
            _service = new SettingsService(_unitOfWork.Object);
        }

        [Test]
        public async Task GetAllAsync_GetAllSettingsAsync_ReturnsThreeSettings()
        {
            // Set up sample data.
            var data = new List<Settings>
            { new Settings { Id = 1, Key = "Key1", Value = "Value1"}, new Settings { Id = 2, Key = "Key2", Value = "Value2"}, new Settings { Id = 3, Key = "Key3", Value = "Value3"} };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Settings.GetAllAsync()).ReturnsAsync(data);

            var result = await _service.GetAllAsync();

            // Cast to list to make assertions.
            var settings = result as IList<Settings> ?? result.ToList();

            Assert.That(settings, Is.TypeOf<List<Settings>>());
            Assert.That(settings.Count, Is.EqualTo(3));
        }
    }
}
