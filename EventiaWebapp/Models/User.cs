namespace EventiaWebapp.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Event> HostedEvents { get; set; }
        public ICollection<Event> JoinEvents { get; set; }
    }
}
