namespace MyApi.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public bool? IsPresent { get; set; }
        
        public int UserId { get; set; }
        public required User User { get; set; }
        
        public int ActivityId { get; set; }
        public required Activity Activity { get; set; }
    }
}
