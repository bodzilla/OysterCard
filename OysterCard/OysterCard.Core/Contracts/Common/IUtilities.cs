using System;
using System.Runtime.InteropServices;

namespace OysterCard.Core.Contracts.Common
{
    /// <summary>
    /// The base utilities class the utility class inherits from.
    /// </summary>
    public interface IUtilities
    {
        /// <summary>
        /// Calculate the age based on date passed in.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="currentDateTime">The date to compare agaisnt. if empty, then use <see cref="DateTime.Now"/>.</param>
        /// <returns></returns>
        int GetAge(DateTime dateOfBirth, [Optional] DateTime currentDateTime);
    }
}
