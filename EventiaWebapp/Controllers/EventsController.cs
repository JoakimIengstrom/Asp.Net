using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyEvents()
        {
            return View();
        }

        public IActionResult ConfirmBooking()
        {
            return View();

        }
    }
}
