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
        private readonly int _userId;
        private readonly IOysterService _oysterService;

        #region Default Constructor

        public OystersController(IOysterService oysterService)
        {
            _userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _oysterService = oysterService;
        }

        #endregion

        public IActionResult Index() => RedirectToAction("Dashboard");

        /// <summary>
        /// Get user's active and approved oysters.
        /// </summary>
        /// <returns></returns>
        [DefaultBreadcrumb("Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var oysters = await _oysterService.GetActiveAndApprovedAsync(_userId);
            return View(oysters.OrderByDescending(x => x.EntityCreated));
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

            oyster.UserId = _userId;

            // Do not need to set the oyster type for this object as this method will handle this.
            await _oysterService.CreateNonVerifiedAsync(oyster);

            return RedirectToAction("Applications", "Oysters", new { applicationSubmitted = true });
        }

        /// <summary>
        /// Get user's active and non-approved oysters.
        /// </summary>
        /// <returns></returns>
        [Breadcrumb("Oyster applications")]
        public async Task<IActionResult> Applications(bool applicationSubmitted)
        {
            var oysters = await _oysterService.GetActiveAndNonApprovedAsync(_userId);
            ViewData["ApplicationSubmitted"] = applicationSubmitted;
            return View(oysters.OrderByDescending(x => x.EntityCreated));
        }
    }
}