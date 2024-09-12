using MyApi.DTOs;

namespace MyApi.DTOs
{
    public class GroupDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
