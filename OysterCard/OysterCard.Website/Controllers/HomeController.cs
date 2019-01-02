using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.Models;
using OysterCard.Core.ViewModels;

namespace OysterCard.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        #region Default Constructor

        public HomeController(IUserService userService) => _userService = userService;

        #endregion

        /// <summary>
        /// Get the current <see cref="User"/> (if logged in) and return it including their associated <see cref="Oyster"/>s.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated) return View();

            var user = await _userService.GetByEmailAsync(User.Identity.Name, x => x.Oysters);
            return View(user);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
