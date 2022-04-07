using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Models
{
    public class EventiaUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    
        public ICollection<EventPartTwo> HostedEvents { get; set; }
        public ICollection<EventPartTwo> JoinEvents { get; set; }
    }
}
