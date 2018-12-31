using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OysterCard.Core.Contracts.Services;

namespace OysterCard.Website.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        #region Default Constructor

        public UsersController(IUserService userService) => _userService = userService;

        #endregion

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{users}")]
        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetAllAsync(x => x.Oysters);
            return Content(users.ToString());
        }

        /// <summary>
        /// Get user by username.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{users}/{email}")]
        public async Task<IActionResult> UserByEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) return View($"Index", "Home");
            var user = await _userService.GetByEmailAsync(email, x => x.Oysters);
            return Content(user != null ? user.ToString() : $"{email} doesn't exist.");
        }
    }
}