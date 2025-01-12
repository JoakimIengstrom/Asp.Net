﻿using EventiaWebapp.Data;
using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventsService 
    {
        private readonly EventiaPartTwoDBContext _ctx;

        public EventsService(EventiaPartTwoDBContext context)
        {
            _ctx = context;
        }

        public EventPartTwo GetOneEvent(int eId)
        {
            var thisEvent = _ctx.Events
                .Include(e => e.Organizer)
                .FirstOrDefault(e => e.EventId == eId);

            return thisEvent;
        }


        public List<EventPartTwo> GetEvents()
        {
            var eventList = _ctx.Events
                .Include(e => e.Organizer)
                .ToList();

            return eventList;
        }
        public async Task<List<EventPartTwo>> HostedEventList(string orgId)
        {
            var hostedEvents = await _ctx.Events
                .Include(e => e.Organizer)
                .Where(e => e.Organizer.Id == orgId)
                .ToListAsync();

            return hostedEvents;
        }


        public EventiaUser GetAttendee(string aID)
        {
            var AttendeeObj = _ctx.Users
                .Include(a => a.JoinEvents)
                .FirstOrDefault(a => a.Id == aID);

            return AttendeeObj;
        }

        public void AttendEvent(string aID, int eID)
        {
            var attendee = _ctx.Users
                .Include(a => a.JoinEvents)
                .FirstOrDefault(a => a.Id == aID);

            var eventParticipation = _ctx.Events
                .FirstOrDefault(e => e.EventId == eID);
           
            attendee.JoinEvents.Add(eventParticipation);
            _ctx.SaveChanges();
        }

        public List<EventPartTwo> GetMyEvents(string aID)
        {
            var attendeeObj = _ctx.Users
                .Include(a => a.JoinEvents)
                .ThenInclude(e => e.Organizer)
                .FirstOrDefault(a => a.Id == aID);

            if (attendeeObj == null) return null; 
           
            var myEvents = attendeeObj.JoinEvents;
            return myEvents.ToList();
            
        }
    }
}