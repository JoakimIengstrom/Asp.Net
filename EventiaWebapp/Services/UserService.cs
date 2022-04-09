using EventiaWebapp.Data;
using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Services
{
    public class UserService
    {
        private readonly EventiaPartTwoDBContext _ctx;
        private readonly UserManager<EventiaUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public UserService(EventiaPartTwoDBContext context, UserManager<EventiaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void GetAttendeeToOrganizer(string aID)
        {
            var newOrganizer = _ctx.Users
                .FirstOrDefault(a => a.Id == aID);

            newOrganizer.OrganizerApplication = true;
            _ctx.SaveChanges();
        }
        
        public List<EventiaUser> NewOrganizers()
        {
            var listNewOrganizer = _ctx.Users
                .Where(u => u.OrganizerApplication == true)
                .ToList();

            return listNewOrganizer;
        }

        public async Task ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            await _userManager.RemoveFromRoleAsync(user, "UserAttende");
            await _userManager.AddToRoleAsync(user, "UserOrganizer");
            user.OrganizerApplication = false;

            _ctx.SaveChangesAsync();
        }
    }

    
}
