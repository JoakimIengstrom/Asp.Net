using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "UserAttendee, UserAdmin")]
        public IActionResult JoinEvent(int eventId)
        {
            var joinEvent = _eventsService.GetOneEvent(eventId);
            return View(joinEvent);
        }

        [Authorize(Roles = "UserAttendee, UserAdmin")]
        public IActionResult ConfirmBooking(int eventId)
        {
            var uId = _userManager.GetUserId(User);
            var aId = _eventsService.GetAttendee(uId);

            _eventsService.AttendEvent(aId.Id, eventId);
            var confirmedEvent = _eventsService.GetOneEvent(eventId);
            return View(confirmedEvent);
        }
    }
}