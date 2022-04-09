using EventiaWebapp.Data;
using EventiaWebapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly EventiaPartTwoDBContext _ctx;
        private readonly UserManager<EventiaUser> _userManager;

        public OrganizerController(EventiaPartTwoDBContext ctx, UserManager<EventiaUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public IActionResult AddEvent()
        {
            return View();
        }

        [Authorize(Roles = "UserOrganizer")]
        public IActionResult HostedEvents()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "UserOrganizer")]
        public async Task<IActionResult> CreateEvent(string title, string description, string place, string adress, DateTime date, int spots_Available)
        {
            var org = await _userManager.GetUserAsync(User);
            var evt = new EventPartTwo
            {
                Title = title,
                Description = description,
                Place = place,
                Adress = adress,
                Date = date,
                Spots_Available = spots_Available,
                Organizer = org
            };

            _ctx.Events.Add(evt);
            _ctx.SaveChanges();
            return RedirectToAction("AddEvent");
        }
    }

    
}
