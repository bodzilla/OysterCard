using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using OysterCard.Core.Contracts;

namespace OysterCard.Core.Models
{
    /// <inheritdoc cref="IdentityUser" />
    /// <summary>
    /// The application user.
    /// </summary>
    public sealed class User : IdentityUser<int>, IEntity
    {
        #region Default Constructor

        /// <inheritdoc />
        public User() => Oysters = new HashSet<Oyster>();

        #endregion

        #region Public Properties

        /// <inheritdoc cref="IEntity" />
        public override int Id { get; set; }

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
        /// The associated list of <see cref="Oyster"/> for this user.
        /// </summary>
        public ICollection<Oyster> Oysters { get; set; }

        #endregion
    }
}
