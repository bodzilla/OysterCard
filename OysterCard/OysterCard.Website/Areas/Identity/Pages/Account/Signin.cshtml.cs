using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OysterCard.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class SigninModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<SigninModel> _logger;

        public SigninModel(SignInManager<User> signInManager, ILogger<SigninModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public UserSigninVM UserSigninVm { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!String.IsNullOrEmpty(ErrorMessage)) ModelState.AddModelError(String.Empty, ErrorMessage);
            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid) return Page();

            var result = await _signInManager.PasswordSignInAsync(UserSigninVm.Email, UserSigninVm.Password, isPersistent: false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User signed in.");
                return LocalRedirect(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }

            // If we got this far, something failed, redisplay form.
            ModelState.AddModelError(String.Empty, "Your credentials were invalid.");
            return Page();
        }
    }
}
