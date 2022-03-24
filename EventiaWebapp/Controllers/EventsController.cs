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
            var joinEvent = _eventsService.GetEvents()
                .Find(e => e.EventId == eventId);
            return View(joinEvent);
        }
        public IActionResult ConfirmBooking(int eventId)
        {
            var aId = _eventsService.GetAttendee(1);
            //Detta kommer ju sedan vara den personen som är inloggad

            if (eventId == null)
            {
                //Gör något form av notering att det inte har gått.
            }

            _eventsService.AttendEvent(aId.AttendeeId, eventId);
            var confirmedEvent = _eventsService.GetEvents()
                .Find(e => e.EventId == eventId);
            return View(confirmedEvent);
        }
    }
}