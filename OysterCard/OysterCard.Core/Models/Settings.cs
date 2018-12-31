using System;
using OysterCard.Core.Contracts;

namespace OysterCard.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The application settings.
    /// </summary>
    public sealed class Settings : IEntity
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
        /// The key for this setting.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The value for this setting.
        /// </summary>
        public string Value { get; set; }

        #endregion
    }
}
