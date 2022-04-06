using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Data
{
    public class DataBase
    {
        private EventiaPartTwoDBContext ctx;
        private UserManager<EventiaUser> userManager;
        //private RoleManager<IdentityRole> roleManager;

        public DataBase(EventiaPartTwoDBContext ctx, UserManager<EventiaUser> uM/* ,RoleManager<IdentityRole> iR */)
        {
            this.ctx = ctx;
            this.userManager = uM;
            //this.roleManager = iR;
        }

        public void PrepDatabase()
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            //ctx.Seed();
        }


    }
}
