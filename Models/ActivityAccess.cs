namespace MyApi.Models
{
    public class ActivityAccess
    {
        public int Id { get; set; }
        
        public int GroupId { get; set; }
        public required Group Group { get; set; }
        
        public int ActivityId { get; set; }
        public required Activity Activity { get; set; }
    }
}
