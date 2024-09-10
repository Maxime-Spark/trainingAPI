namespace MyApi.Models
{
    public class Registration
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        
        public int ActivityId { get; set; }
        public required Activity Activity { get; set; }
    }
}
