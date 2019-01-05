using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OysterCard.Core.Models;

namespace OysterCard.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class SignoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<SignoutModel> _logger;

        public SignoutModel(SignInManager<User> signInManager, ILogger<SignoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation($"{User.Identity.Name} signed out.");
            if (returnUrl != null) return LocalRedirect(returnUrl);
            return Page();
        }
    }
}
