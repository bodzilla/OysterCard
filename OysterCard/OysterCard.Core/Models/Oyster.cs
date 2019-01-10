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
        /// The user's forename(s).
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// The user's surname(s).
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The user's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The user's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The user's city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The user's post code.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// The oyster type.
        /// </summary>
        public OysterType OysterType { get; protected set; }

        /// <summary>
        /// The oyster state.
        /// </summary>
        public OysterState OysterState { get; set; }

        /// <summary>
        /// The rate of cost for each travel.
        /// </summary>
        public decimal Rate { get; protected set; }

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
