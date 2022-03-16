using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Spots_Available { get; set; }

        
        public int OrganizerId { get; set; }
        public virtual Organizer Organizer { get; set; }

        
        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
