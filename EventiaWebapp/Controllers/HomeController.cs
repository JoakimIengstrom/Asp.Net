using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Events()
        {
            return View();
        }

        [Authorize(Roles = "UserAttendee")]
        public IActionResult MyEvents()
        {
            return View();
        }
    }
}