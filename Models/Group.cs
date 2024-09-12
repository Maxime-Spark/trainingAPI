

namespace MyApi.Models
{
    public class Group
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
