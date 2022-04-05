using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EventPartTwo> HostedEvents { get; set; }
        public ICollection<EventPartTwo> JoinEvents { get; set; }
    }
}
