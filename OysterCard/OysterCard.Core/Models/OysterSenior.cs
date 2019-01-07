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
            OysterType = OysterType.Senior;
            Rate = (decimal)1.50;
        }

        #endregion
    }
}
