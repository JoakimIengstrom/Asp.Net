using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsController : Controller
    {

        private readonly EventsService _eventsService;
        
        public EventsController(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        public IActionResult JoinEvent(int eventId)
        {
            var data = _eventsService.GetEvents()
                .Find(e => e.EventId == eventId);
            return View(data);
        }
        public IActionResult ConfirmBooking(int eventId)
        {
            return View(eventId);
        }
    }
}