using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace OysterCard.Website.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The base controller.
    /// </summary>
    public class ControllerBase : Controller
    {
        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
