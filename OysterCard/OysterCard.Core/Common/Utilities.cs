using System;
using System.Runtime.InteropServices;
using OysterCard.Core.Contracts.Common;

namespace OysterCard.Core.Common
{
    /// <inheritdoc />
    public sealed class Utilities : IUtilities
    {
        /// <inheritdoc />
        public int GetAge(DateTime dateOfBirth, [Optional] DateTime fromDateTime)
        {
            // If current date hasn't been passed in, use now.
            if (fromDateTime == DateTime.MinValue) fromDateTime = DateTime.Now;

            int age = fromDateTime.Year - dateOfBirth.Year;

            // If we haven't reached the birth month and day yet, -1 from age.
            if (fromDateTime.Month < dateOfBirth.Month || fromDateTime.Month == dateOfBirth.Month && fromDateTime.Day < dateOfBirth.Day) age--;
            return age;
        }
    }
}
