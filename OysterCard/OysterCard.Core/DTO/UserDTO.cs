using System;
using System.Collections.Generic;
using OysterCard.Core.Contracts;
using OysterCard.Core.Models;

namespace OysterCard.Core.DTO
{
    /// <inheritdoc />
    /// <summary>
    /// The <see cref="User" /> data transfer object.
    /// </summary>
    public sealed class UserDTO : IDTO
    {
        public int Id { get; set; }

        public DateTime EntityCreated { get; set; }

        public string Email { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public IEnumerable<Oyster> Oysters { get; set; }
    }
}
