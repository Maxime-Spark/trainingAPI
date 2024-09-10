using MyApi.DTOs;

namespace MyApi.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<RegistrationDto> Registrations { get; set; } = new List<RegistrationDto>();
    }
}
