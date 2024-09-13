namespace MyApi.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation property
        public ICollection<Registration>? Registrations { get; set; } = [];
        public ICollection<ActivityAccess>? ActivityAccesses { get; set; } = [];
    }
}
