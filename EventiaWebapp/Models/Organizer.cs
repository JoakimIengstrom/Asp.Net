using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Organizer
    {
        [Key]
        public int OrganizerId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}
