using System;
using System.Runtime.InteropServices;
using OysterCard.Core.Contracts.Common;

namespace OysterCard.Core.Common
{
    /// <inheritdoc />
    public sealed class Utilities : IUtilities
    {
        /// <inheritdoc />
        public int GetAge(DateTime dateOfBirth, [Optional] DateTime currentDateTime)
        {
            // If current date hasn't been passed in, use now.
            if (currentDateTime == DateTime.MinValue) currentDateTime = DateTime.Now;

            int age = currentDateTime.Year - dateOfBirth.Year;

            // If we haven't reached the birth month and day yet, -1 from age.
            if (currentDateTime.Month < dateOfBirth.Month || currentDateTime.Month == dateOfBirth.Month && currentDateTime.Day < dateOfBirth.Day) age--;
            return age;
        }
    }
}
