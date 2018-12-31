using Microsoft.AspNetCore.Identity;

namespace OysterCard.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The application role.
    /// </summary>
    public sealed class Role : IdentityRole<int>
    {
        #region Public Properties

        /// <summary>
        /// The role's description.
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
