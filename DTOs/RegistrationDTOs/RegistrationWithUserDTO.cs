namespace MyApi.DTOs
{
    public class RegistrationWithUserDto
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required int ActivityId { get; set; }

        public required UserDto User { get; set; }
    }
}
