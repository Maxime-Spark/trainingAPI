using MyApi.DTOs;

namespace MyApi.DTOs
{
    public class ActivityAccessDto
    {
        public required int Id { get; set; }
        public required int GroupId { get; set; }

        public required GroupRawDto Group { get; set; }
    }
}
