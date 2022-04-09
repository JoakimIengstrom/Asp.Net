using System.Security.Cryptography.X509Certificates;
using EventiaWebapp.Data;
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
        private readonly EventiaPartTwoDBContext _ctx;


        public AdminController(UserService userService, EventiaPartTwoDBContext ctx)
        {
            _userService = userService;
            _ctx = ctx;
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
