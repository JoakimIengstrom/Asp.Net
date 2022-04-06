using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventiaWebapp.Models
{
    public class EventPartTwo
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public int Spots_Available { get; set; }

        //[ForeignKey("Organizer")]
        //public int OrganizerId { get; set; }

        [InverseProperty("HostedEvents")]
        [DisplayName ("Organizer")]
        public /*virtual*/ EventiaUser Organizer { get; set; }

        [InverseProperty("JoinEvents")]
        public /*virtual*/ ICollection<EventiaUser>? Attendees { get; set; }
    }
}
