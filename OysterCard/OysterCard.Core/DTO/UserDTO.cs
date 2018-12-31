using System;
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

        public string Username { get; set; }

        public string Email { get; set; }

        public int Level { get; set; }

        public double Experience { get; set; }
    }
}
