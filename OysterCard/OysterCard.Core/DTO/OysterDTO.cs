using System;
using OysterCard.Core.Contracts;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;

namespace OysterCard.Core.DTO
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="Oyster" /> data transfer object.
    /// </summary>
    public sealed class OysterDTO : IDTO
    {
        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public OysterType OysterType { get; set; }

        public decimal Rate { get; set; }

        public decimal Balance { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
