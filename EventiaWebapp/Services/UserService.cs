using EventiaWebapp.Data;
using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task <List<EventiaUser>> userList()
        {
            var userList = _ctx.Users
                .OrderBy(u => u.UserName)
                .ToList();

            return userList;
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
