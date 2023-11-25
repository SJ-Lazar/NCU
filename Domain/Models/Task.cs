namespace Domain.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public int? CreatorID { get; set; }
        public int? AssigneeID { get; set; }
        public int? ProjectID { get; set; }
    }


}
