using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OysterCard.Core.Contracts.Services;
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

        [DefaultBreadcrumb("Home")]

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetByEmailAsync(User.Identity.Name, x => x.Oysters);
            return View(user);
        }

        [Breadcrumb("Apply")]
        public IActionResult Apply() => View();
    }
}