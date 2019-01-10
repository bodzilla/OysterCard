using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OysterCard.Core.Contracts.UOW;
using OysterCard.Core.Models;
using OysterCard.Persistence;
using OysterCard.Persistence.UOW;
using OysterCard.UnitTests.Services;

namespace OysterCard.UnitTests.UOW
{
    /// <summary>
    /// This unit test class is to just showcase how testing can be handled for entity framework core.
    /// </summary>
    [TestFixture]
    public class SettingsUOWTests
    {
        private ISettingsUOW _unitOfWork;

        [SetUp]
        public void Setup() => ServicesInitializer.ConfigureMappings();

        private void SetUpContext()
        {
#pragma warning disable 618
            // Set up in memory context.
            var options = new DbContextOptionsBuilder<OysterCardContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
#pragma warning restore 618

            var context = new OysterCardContext(options);

            // Assign the mocked db context to the settings unit of work.
            _unitOfWork = new SettingsUOW(context);
        }

        [TestCase("Key", "Value")]
        public void AddAsync_AddSettingAsync_ReturnsPass(string key, string value)
        {
            SetUpContext();

            // Set up sample data.
            var data = new Settings { Key = key, Value = value };

            Assert.DoesNotThrowAsync(async () =>
            {
                await _unitOfWork.Settings.AddAsync(data);
                await _unitOfWork.CompleteAsync();
            });
        }

        [TestCase("Key", "Value")]
        public async Task GetAllAsync_GetAllSettingAsync_ReturnsOneSetting(string key, string value)
        {
            SetUpContext();

            // Set up sample data.
            var data = new Settings { Key = key, Value = value };

            // Act.
            await _unitOfWork.Settings.AddAsync(data);
            await _unitOfWork.CompleteAsync();
            var settings = await _unitOfWork.Settings.GetAllAsync();

            Assert.That(settings.Count(), Is.EqualTo(1));
        }
    }
}
