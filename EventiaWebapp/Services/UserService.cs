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

        public UserService(EventiaPartTwoDBContext context, UserManager<EventiaUser> userManager)
        {
            _ctx = context;
            _userManager = userManager;
        }

        public async Task<List<EventiaUser>> userList()
        {
            var userList = _ctx.Users
                .OrderBy(u => u.UserName)
                .ToList();

            return userList;
        }

        public async Task RequestToBeAnOrganizer(string aID)
        {
            var newOrganizer = await _ctx.Users
                .FirstOrDefaultAsync(a => a.Id == aID);

            newOrganizer.OrganizerApplication = true;
            await _ctx.SaveChangesAsync();
        }

        public async Task AddNewRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            //await _userManager.RemoveFromRoleAsync(user, "UserAttende"); //Changed from changeRole to AddRole, so keeping this right now as a reminder. 
            await _userManager.AddToRoleAsync(user, "UserOrganizer");
            user.OrganizerApplication = false;

            await _ctx.SaveChangesAsync();
        }
    }

    
}
