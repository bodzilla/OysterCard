using System;
using System.ComponentModel.DataAnnotations;
using OysterCard.Core.Attributes;
using OysterCard.Core.Enums;
using OysterCard.Core.Models;

namespace OysterCard.Core.ViewModels
{
    /// <summary>
    /// The view model for the <see cref="Oyster"/> application page.
    /// </summary>
    public class OysterApplicationVM
    {
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Forename")]
        public string Forename { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "The {0} must be a valid date.")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        [DateOfBirthRange]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Post code")]
        public string PostCode { get; set; }

        [Required]
        [EnumDataType(typeof(OysterType), ErrorMessage = "The {0} is not a valid {0}.")]
        [Display(Name = "Oyster type")]
        public OysterType OysterType { get; set; }

        public int UserId { get; set; }
    }
}
