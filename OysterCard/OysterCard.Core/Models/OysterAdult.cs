using OysterCard.Core.Enums;

namespace OysterCard.Core.Models
{
    /// <inheritdoc cref="Oyster" />
    /// <summary>
    /// The adult oyster.
    /// </summary>
    public class OysterAdult : Oyster
    {
        #region Default Constructor

        /// <inheritdoc />
        public OysterAdult()
        {
            _oysterType = OysterType.Adult;
            _rate = (decimal)2.5;
        }

        #endregion
    }
}
