using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventsService 
    {
        private EventiaDbContext ctx;
        public List<Event>? EventList { get; set; }
        public List<Attendee> AttendeeList { get; set; }
        public List<Organizer> Organizers { get; set; }
        

        public EventsService(EventiaDbContext context)
        {
            ctx = context;
        }

        public List<Event> GetEvents()
        {
            using var ctx = this.ctx;
            EventList = ctx.Events
                .Include(e => e.Organizer)
                .ToList();

            return EventList;
        }

        public Attendee GetAttendee()
        {
            
            throw new NotImplementedException();
        }

        public bool AttendEvent(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetMyEvents()
        {
            throw new NotImplementedException();
        }
    }
}