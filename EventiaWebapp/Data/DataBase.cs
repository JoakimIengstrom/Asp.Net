using System.Diagnostics;
using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Data
{
    public class DataBase
    {
        private EventiaPartTwoDBContext _ctx;
        private UserManager<EventiaUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public DataBase(EventiaPartTwoDBContext ctx, UserManager<EventiaUser> uM, RoleManager<IdentityRole> iR)
        {
            this._ctx = ctx;
            this._userManager = uM;
            this._roleManager = iR;
        }

        public async Task PrepDatabase()
        {
            await _ctx.Database.EnsureDeletedAsync();
            await _ctx.Database.EnsureCreatedAsync();
            await Seed();
        }

        public async Task Seed()
        {
            List<EventiaUser> organizers = new List<EventiaUser>
            {
                new() {UserName = "America_Events", Email = "america.events@ticket.com", PhoneNumber = "0771-707070"},
                new() {UserName = "Texas_Music", Email = "texas@events.com", PhoneNumber = "08-6650100"},
                new() {UserName = "California_Dreams", Email = "carlifona@usa.com", PhoneNumber = "031-3684500"}
            };

            foreach (var organizer in organizers) 
            {
                await _userManager.CreateAsync(organizer, password: "Qwerty87!");
            };
            

            var events = new List<EventPartTwo>
            {
                new()
                {
                        Title = "Coachella - Friday",
                        Description =
                            "You can’t have a list of music festivals without mentioning one of the biggest in the United States."+
                            "Attracting more than 250,000 revelers annually, Coachella is at the top of everyone’s list of must-experience events."+
                            "Aside from the music, the festival is also known for its celebrity appearances, comeback performances, and fashion sense."+
                            "In fact, Coachella is considered a trendsetter in streetwear, so don’t leave home without dressing to impress."+
                            "This year’s Coachella is headlined by Rage Against the Machine with an initial lineup that includes Swedish House Mafia and Travis Scott."+"" +
                            "While the official list is in the works, you might want to book your tickets early.",
                        Place = "Indio, Carlifonia",
                        Adress = "Thousand Palms, CA 92276, USA",
                        Date = new DateTime(2022, 04, 15),
                        Spots_Available = 15000,
                        Organizer = organizers[2],
                        OrganizerName = organizers[2].UserName,
                },
                new()
                {
                        Title = "Coachella - Saturday",
                        Description =
                            "You can’t have a list of music festivals without mentioning one of the biggest in the United States."+
                            "Attracting more than 250,000 revelers annually, Coachella is at the top of everyone’s list of must-experience events."+
                            "Aside from the music, the festival is also known for its celebrity appearances, comeback performances, and fashion sense."+
                            "In fact, Coachella is considered a trendsetter in streetwear, so don’t leave home without dressing to impress."+
                            "This year’s Coachella is headlined by Rage Against the Machine with an initial lineup that includes Swedish House Mafia and Travis Scott."+"" +
                            "While the official list is in the works, you might want to book your tickets early.",
                        Place = "Indio, Carlifonia",
                        Adress = "Thousand Palms, CA 92276, USA",
                        Date = new DateTime(2022, 04, 16),
                        Spots_Available = 15000,
                        Organizer = organizers[2],
                        OrganizerName = organizers[2].UserName,
                },
                new()
                    {
                        Title = "South by Southwest",
                        Description =
                            "The city of Austin has been touted as the South’s progressive center. It’s for this reason that makes Austin an ideal place for innovative acts to rise. "+
                            "While it features a separate event for films and comedy performers, "+
                            "South by Southwest (popularly known as South By or SXSW) Musical Festival provides the perfect venue for up and coming bands to share the stage with established acts. "+
                            "Inviting over hundreds of global talents to perform in several venues across the city, SXSW is known for launching independent musicians to international recognition. "+
                            "If you are looking to update your Spotify playlist with the freshest bands, then head on over to Austin this March and experience what bands like Horsegirl, "+
                            "Family Jools, and Bread Pilot have to offer.",
                        Place = "Austin, Texas",
                        Adress = "4801 La Crosse Ave, Austin, TX 78739, USA",
                        Date = new DateTime(2022, 10, 09),
                        Spots_Available = 5000,
                        Organizer = organizers[0],
                        OrganizerName = organizers[0].UserName,
                },
                new()
                {
                        Title = "Austin City Limits Music Festival",
                        Description =
                            "Head back to Austin in the Fall and attend another exciting event in the mold of the Austin City Limits Music Festival. "+
                            "Happening in Zilker Park, this eight-stage festival is happening over two weekends and features mainstream acts. "+
                            "This year’s lineup includes Billie Eilish, Megan Thee Stallion, Doja Cat, and DaBaby. Apart from a star-studded lineup, "+
                            "the festival also promises good food and fun activities perfect for the whole family. If you want to make the most out of the ACL experience, "+
                            "consider getting VIP passes and score the best band autographs from your favorite artists.+"+
                            "This year is shaping up to be one of the best for music festivals. Fans can look forward to events featuring their favorite performers."+
                            "You just have to ask yourself when and where you are going to meet them live. "+
                            "If you want to take a break from work or travel out of town after staying too long indoors, check out this list of the hottest music festivals you wouldn’t want to miss. "+
                            "Obviously, these are subject to change due to current circumstances, but hopefully all move forward as planned.",
                        Place = "Austin, Texas",
                        Adress = "4801 La Crosse Ave, Austin, TX 78739, USA",
                        Date = new DateTime(2022, 10, 15),
                        Spots_Available = 50000,
                        Organizer = organizers[1],
                        OrganizerName = organizers[1].UserName,
                },
            };

            _ctx.AddRange(events);
            _ctx.SaveChanges();

            List<EventiaUser> attendees = new List<EventiaUser>
            {
                new() {UserName = "user1", FirstName = "Joakim", Email = "joakim@gmail.com", PhoneNumber = "0701-123456", JoinEvents = new List<EventPartTwo>{events[2]}},
                new() {UserName = "user2", FirstName = "Theo", Email = "theo@gmail.com", PhoneNumber = "0702-123456"},
                new() {UserName = "user3", FirstName = "AnnaMärta", Email = "annamarta@gmail.com", PhoneNumber = "0703-123456"}
            };

            foreach (var attendee in attendees)
            {
                await _userManager.CreateAsync(attendee, password: "Qwerty87!");
            };
        }

    }
}
