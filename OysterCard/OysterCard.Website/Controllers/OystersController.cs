using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OysterCard.Core.Contracts.Services;
using OysterCard.Core.ViewModels;
using SmartBreadcrumbs;

namespace OysterCard.Website.Controllers
{
    [Authorize]
    public class OystersController : Controller
    {
        private readonly IOysterService _oysterService;

        #region Default Constructor

        public OystersController(IUserService userService, IOysterService oysterService) => _oysterService = oysterService;

        #endregion

        public IActionResult Index() => RedirectToAction("Dashboard");

        /// <summary>
        /// Get user's active and verified oysters.
        /// </summary>
        /// <returns></returns>
        [DefaultBreadcrumb("Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var activeAndVerifiedOysters = await _oysterService.GetListAsync(x =>
            x.UserId == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            && x.EntityActive
            && x.Verified);

            return View(activeAndVerifiedOysters);
        }

        [Breadcrumb("Apply for an Oyster")]
        public IActionResult Apply() => View();

        /// <summary>
        /// Apply for <see cref="T:OysterCard.Core.Models.Oyster"/>s for a <see cref="T:OysterCard.Core.Models.User"/>.
        /// </summary>
        /// <param name="oyster"></param>
        /// <returns></returns>
        public async Task<IActionResult> ApplyForOyster(OysterApplicationVM oyster)
        {
            if (!ModelState.IsValid) return View("Apply");
            oyster.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Set the user's id.
            await _oysterService.CreateNonVerifiedAsync(oyster);
            return RedirectToAction("Applications", "Oysters", new { applicationSubmitted = true });
        }

        /// <summary>
        /// Get user's active and non-verified oysters.
        /// </summary>
        /// <returns></returns>
        [Breadcrumb("Oyster applications")]
        public async Task<IActionResult> Applications(bool applicationSubmitted)
        {
            var activeAndNonVerifiedOysters = await _oysterService.GetListAsync(x =>
            x.UserId == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            && x.EntityActive
            && !x.Verified);

            ViewData["ApplicationSubmitted"] = applicationSubmitted;
            return View(activeAndNonVerifiedOysters.OrderByDescending(x => x.EntityCreated));
        }
    }
}