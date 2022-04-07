using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class OrganizerController : Controller
    {
        public IActionResult AddEvent()
        {
            return View();
        }
    }
}
