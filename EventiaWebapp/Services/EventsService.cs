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
            var EventList = _ctx.Events
                .Include(e => e.Organizer)
                .ToList();

            return EventList;
        }

        public Attendee GetAttendee(int userID)
        {
            var AttendeeObj = _ctx.Attendees
                .Include(a => a.Events)
                .FirstOrDefault(a => a.Id == userID);

            return AttendeeObj;
        }

        public bool AttendEvent(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetMyEvents(int userID)
        {
            var AttendeeObj = _ctx.Attendees
                .Include(a => a.Events)
                .ThenInclude(e => e.Organizer)
                .FirstOrDefault(a => a.Id == userID);
            var MyEvents = AttendeeObj.Events;
            return MyEvents.ToList();
        }
    }
}