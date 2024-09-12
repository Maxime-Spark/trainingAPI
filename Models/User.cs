namespace MyApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

        public required int GroupId { get; set; }
        public required Group Group { get; set; }
        
        // Navigation property
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
