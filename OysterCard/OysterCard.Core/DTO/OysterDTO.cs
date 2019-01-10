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

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public OysterType OysterType { get; set; }

        public OysterState OysterState { get; set; }

        public decimal Rate { get; set; }

        public decimal Balance { get; set; }

        public bool Verified { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
