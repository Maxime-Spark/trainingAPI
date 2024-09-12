namespace MyApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        
        // Navigation property
        public ICollection<Registration>? Registrations { get; set; } = new List<Registration>();
    }
}
