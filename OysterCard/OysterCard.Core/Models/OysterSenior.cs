using OysterCard.Core.Enums;

namespace OysterCard.Core.Models
{
    /// <inheritdoc cref="Oyster" />
    /// <summary>
    /// The junior oyster.
    /// </summary>
    public class OysterSenior : Oyster
    {
        #region Default Constructor

        /// <inheritdoc />
        public OysterSenior()
        {
            _oysterType = OysterType.Senior;
            _rate = (decimal)1.50;
        }

        #endregion
    }
}
