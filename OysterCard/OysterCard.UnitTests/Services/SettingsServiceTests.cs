using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            {
                new Settings { Id = 1, Key = "Key1", Value = "Value1"},
                new Settings { Id = 2, Key = "Key2", Value = "Value2"},
                new Settings { Id = 3, Key = "Key3", Value = "Value3"}
            };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Settings.GetAllAsync()).ReturnsAsync(data);

            var result = await _service.GetAllAsync();

            // Cast to list to make assertions.
            var settings = result as IList<Settings> ?? result.ToList();

            Assert.That(settings, Is.TypeOf<List<Settings>>());
            Assert.That(settings.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetOysterTypeAgeLimitsAsync_GetOysterTypeAgeLimitSettingsAsync_ReturnsFourAgeLimitSettings()
        {
            // Set up sample data.
            var data = new List<Settings>
                {
                    new Settings { Id = 1, Key = "LowerAgeLimitJunior", Value = "0"},
                    new Settings { Id = 2, Key = "UpperAgeLimitJunior", Value = "15"},
                    new Settings { Id = 3, Key = "LowerAgeLimitAdult", Value = "16"},
                    new Settings { Id = 4, Key = "UpperAgeLimitAdult", Value = "74"}
                };

            // Ensure this method returns the sample data.
            _unitOfWork.Setup(x => x.Settings.GetListAsync(It.IsAny<Expression<Func<Settings, bool>>>(), It.IsAny<Expression<Func<Settings, object>>[]>()))
                .ReturnsAsync(data);

            var result = await _service.GetOysterTypeAgeLimitsAsync();

            // Cast to list to make assertions.
            var settings = result as IList<Settings> ?? result.ToList();

            Assert.That(settings, Is.TypeOf<List<Settings>>());
            Assert.That(settings.Count, Is.EqualTo(4));
        }
    }
}
