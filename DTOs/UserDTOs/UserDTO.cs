using MyApi.DTOs;

namespace MyApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public int? GroupId { get; set; }
        public GroupRawDto? Group { get; set; }
    }
}
