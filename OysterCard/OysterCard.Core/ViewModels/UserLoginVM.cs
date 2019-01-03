using OysterCard.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace OysterCard.Core.ViewModels
{
    /// <summary>
    /// The view model for the <see cref="User"/> login page.
    /// </summary>
    public sealed class UserLoginVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
