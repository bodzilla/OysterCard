using OysterCard.Core.Enums;

namespace OysterCard.Core.Models
{
    /// <inheritdoc cref="Oyster" />
    /// <summary>
    /// The junior oyster.
    /// </summary>
    public class OysterJunior : Oyster
    {
        #region Default Constructor

        /// <inheritdoc />
        public OysterJunior()
        {
            _oysterType = OysterType.Junior;
            _rate = 1;
        }

        #endregion
    }
}
