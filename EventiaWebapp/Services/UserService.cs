using EventiaWebapp.Data;
using EventiaWebapp.Models;

namespace EventiaWebapp.Services
{
    public class UserService
    {
        private readonly EventiaPartTwoDBContext _ctx;
        

        public UserService(EventiaPartTwoDBContext context)
        {
            _ctx = context;
        }

        public void GetAttendeeToOrganizer(string aID)
        {
            var newOrganizer = _ctx.Users
                .FirstOrDefault(a => a.Id == aID);

            newOrganizer.OrganizerApplication = true;
            _ctx.SaveChanges();
        }
    }

    
}
