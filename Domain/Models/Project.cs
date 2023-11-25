namespace Domain.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ManagerID { get; set; }
    }


}
