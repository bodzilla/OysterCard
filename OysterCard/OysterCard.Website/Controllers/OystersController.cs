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
        private readonly IUserService _userService;
        private readonly IOysterService _oysterService;

        #region Default Constructor

        public OystersController(IUserService userService, IOysterService oysterService)
        {
            _userService = userService;
            _oysterService = oysterService;
        }

        #endregion

        [DefaultBreadcrumb("Dashboard")]

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetByEmailAsync(User.Identity.Name, x => x.Oysters);
            return View(user);
        }

        [Breadcrumb("Apply for an Oyster")]
        public IActionResult Apply() => View();

        [HttpPost]
        public async Task<IActionResult> ApplyForOyster(OysterApplicationVM oyster)
        {
            if (!ModelState.IsValid) return View("Apply");
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            oyster.UserId = userId;
            await _oysterService.ApplyForOysters(oyster);
            return Ok("Oyster application sent!");
        }
    }
}