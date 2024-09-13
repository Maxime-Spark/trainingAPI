using MyApi.DTOs;

namespace MyApi.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<RegistrationWithUserDto>? Registrations { get; set; } = [];
        public ICollection<ActivityAccessDto>? ActivityAccesses { get; set; } = [];
    }
}
