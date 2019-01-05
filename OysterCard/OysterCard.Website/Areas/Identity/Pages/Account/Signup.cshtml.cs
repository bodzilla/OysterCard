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
    public class SignupModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<SignupModel> _logger;
        private readonly IEmailSender _emailSender;

        public SignupModel(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<SignupModel> logger, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public UserSignupVM UserSignupVm { get; set; }

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
                UserName = UserSignupVm.Email,
                Email = UserSignupVm.Email
            };

            var result = await _userManager.CreateAsync(user, UserSignupVm.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User {user.Email} created.");
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                string callbackUrl = Url.Page("/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(UserSignupVm.Email, "Verify your account",
                    $"Please verify your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form.
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            return Page();
        }
    }
}
