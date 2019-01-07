using System;
using System.ComponentModel.DataAnnotations;

namespace OysterCard.Core.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// A custom date attribute to set the <see cref="T:System.DateTime" /> range from:
    /// Lower limit: current year - 150 years.
    /// Upper limit: current year.
    /// </summary>
    public class DateOfBirthRangeAttribute : RangeAttribute
    {
        public DateOfBirthRangeAttribute() : base(typeof(DateTime),
            DateTime.Today.AddYears(-150).ToString("dd/MM/yyyy"), DateTime.Today.ToString("dd/MM/yyyy"))
        {
        }
    }
}
