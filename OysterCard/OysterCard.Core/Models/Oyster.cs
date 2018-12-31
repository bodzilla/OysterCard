using System;
using OysterCard.Core.Contracts;
using OysterCard.Core.Enums;

namespace OysterCard.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The base entity for oysters.
    /// Should not used as an oyster object itself.
    /// </summary>
    public abstract class Oyster : IEntity
    {
        #region Private Members

        /// <summary>
        /// The oyster type.
        /// </summary>
        protected OysterType _oysterType;

        /// <summary>
        /// The rate of cost for each travel.
        /// </summary>
        protected decimal _rate = 0;

        #endregion

        #region Public Properties

        /// <inheritdoc />
        public int Id { get; set; }

        /// <inheritdoc />
        public DateTime EntityCreated { get; set; }

        /// <inheritdoc />
        public bool EntityActive { get; set; }

        /// <inheritdoc />
        public byte[] EntityVersion { get; set; }

        /// <summary>
        /// The oyster type.
        /// </summary>
        public OysterType OysterType => _oysterType;

        /// <summary>
        /// The rate of cost for each travel.
        /// </summary>
        public decimal Rate => _rate;

        /// <summary>
        /// The current balance.
        /// Has a default starting balance of 0.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// The id of the associated <see cref="Models.User"/> for this oyster.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The associated <see cref="Models.User"/> for this oyster.
        /// </summary>
        public User User { get; set; }

        #endregion
    }
}
