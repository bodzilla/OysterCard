using Microsoft.AspNetCore.Mvc;

namespace OysterCard.Website.Controllers
{
    public class OystersController : Controller
    {
        public IActionResult Apply()
        {
            return View();
        }
    }
}