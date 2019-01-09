using System;
using NUnit.Framework;
using OysterCard.Core.Common;
using OysterCard.Core.Contracts.Common;

namespace OysterCard.UnitTests.Common
{
    [TestFixture]
    public class UtilitiesTests
    {
        private IUtilities _utilities;

        [SetUp]
        public void Setup() => _utilities = new Utilities();

        /// <summary>
        /// </summary>
        /// <param name="dateOfBirth">Format: MM/dd/yyyy</param>
        /// <param name="currentDateTime">Format: MM/dd/yyyy</param>
        /// <param name="age"></param>
        [TestCase("12/31/1994", "01/01/2019", 24)]
        [TestCase("01/01/2000", "01/01/2019", 19)]
        [TestCase("01/12/2000", "01/01/2019", 18)]
        public void GetAge_CheckCorrectAgeReturned_ReturnsCorrectAge(DateTime dateOfBirth, DateTime currentDateTime, int age)
        {
            int result = _utilities.GetAge(dateOfBirth, currentDateTime);
            Assert.That(result, Is.EqualTo(age));
        }
    }
}
