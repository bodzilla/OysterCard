using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;

namespace OysterCard.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<RegisterModel> logger, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public UserRegisterVM UserRegisterVm { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid) return Page();

            var user = new User
            {
                EntityCreated = DateTime.Now,
                EntityActive = true,
                UserName = UserRegisterVm.Email,
                Email = UserRegisterVm.Email,
                Forename = UserRegisterVm.Forename,
                Surname = UserRegisterVm.Surname
            };

            var result = await _userManager.CreateAsync(user, UserRegisterVm.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                string callbackUrl = Url.Page("/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(UserRegisterVm.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form.
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            return Page();
        }
    }
}
