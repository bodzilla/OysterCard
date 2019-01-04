using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OysterCard.Core.ViewModels;

namespace OysterCard.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => User.Identity.IsAuthenticated ? (IActionResult)RedirectToAction("Index", "Oysters") : View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
