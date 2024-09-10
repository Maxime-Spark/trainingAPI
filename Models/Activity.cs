namespace MyApi.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

         // Navigation property
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
