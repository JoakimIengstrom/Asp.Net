using EventiaWebapp.Data;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "UserAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "UserAdmin")]
        public IActionResult OrganizerList()
        {
            return View();
        }

        [Authorize(Roles = "UserAdmin")]
        public async Task<IActionResult> AddNewOrganizer(string userId)
        {
            await _userService.AddNewRole(userId);
            return View();
        }
    }
}
