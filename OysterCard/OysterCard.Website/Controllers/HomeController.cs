using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.ViewModels;

namespace OysterCard.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        #region Default Constructor

        public HomeController(IUserService userService) => _userService = userService;

        #endregion

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
