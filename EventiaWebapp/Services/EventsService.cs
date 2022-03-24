using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventsService 
    {
        private EventiaDbContext _ctx;

        public EventsService(EventiaDbContext context)
        {
            _ctx = context;
        }

        public List<Event> GetEvents()
        {
            var eventList = _ctx.Events
                .Include(e => e.Organizer)
                .ToList();

            return eventList;
        }

        public Attendee GetAttendee(int aID)
        {
            var AttendeeObj = _ctx.Attendees
                .Include(a => a.Events)
                .FirstOrDefault(a => a.AttendeeId == aID);

            return AttendeeObj;
        }

        public void AttendEvent(int aID, int eID)
        {
            var attendee = _ctx.Attendees
                .Include(a => a.Events)
                .FirstOrDefault(a => a.AttendeeId == aID);

            var eventParticipation = _ctx.Events
                .FirstOrDefault(e => e.EventId == eID);
           
            attendee.Events.Add(eventParticipation);
            _ctx.SaveChanges();
        }

        public List<Event> GetMyEvents(int aID)
        {
            var attendeeObj = _ctx.Attendees
                .Include(a => a.Events)
                .ThenInclude(e => e.Organizer)
                .FirstOrDefault(a => a.AttendeeId == aID);

            var myEvents = attendeeObj.Events;

            return myEvents.ToList();
        }
    }
}