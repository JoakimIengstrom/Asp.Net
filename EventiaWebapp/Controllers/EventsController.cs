using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsController : Controller
    {

        private readonly EventsService _eventsService;
        private readonly UserManager<EventiaUser> _userManager;

        public EventsController(EventsService eventsService, UserManager<EventiaUser> userManager)
        {
            _eventsService = eventsService;
            _userManager = userManager;
        }

        public IActionResult JoinEvent(int eventId)
        {
            var joinEvent = _eventsService.GetEvents()
                .Find(e => e.EventId == eventId);
            return View(joinEvent);
        }
        public IActionResult ConfirmBooking(int eventId)
        {
            var uId = _userManager.GetUserId(User);
            var aId = _eventsService.GetAttendee(uId);

            _eventsService.AttendEvent(aId.Id, eventId);
            var confirmedEvent = _eventsService.GetEvents()
                .Find(e => e.EventId == eventId);
            return View(confirmedEvent);
        }
    }
}