namespace MyApi.DTOs
{
    public class RegistrationRawDto
    {
        public int Id { get; set; }
        public bool? IsPresent { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
    }
}
