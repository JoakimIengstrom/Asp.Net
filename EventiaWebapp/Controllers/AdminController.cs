using System.Security.Cryptography.X509Certificates;
using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly UserManager<EventiaUser> _userManager;

        public AdminController(EventsService eventsService, UserManager<EventiaUser> userManager, UserService userService)
        {
            _userManager = userManager;
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
            await _userService.ChangeRole(userId);
            return View();
        }
    }
}
