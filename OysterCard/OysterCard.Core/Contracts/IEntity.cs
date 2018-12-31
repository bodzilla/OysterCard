using System;

namespace OysterCard.Core.Contracts
{
    /// <summary>
    /// The base interface where all models inherit from.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The unique identifier for this entity type.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The <see cref="DateTime"/> that this entity was created.
        /// </summary>
        DateTime EntityCreated { get; set; }

        /// <summary>
        /// The active status of this entity.
        /// </summary>
        bool EntityActive { get; set; }

        /// <summary>
        /// The current version of this entity in the database for concurrency.
        /// </summary>
        byte[] EntityVersion { get; set; }
    }
}
