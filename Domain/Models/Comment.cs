namespace Domain.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int? TaskID { get; set; }
        public int? UserID { get; set; }
        public string? CommentText { get; set; }
        public DateTime? CreatedAt { get; set; }
    }


}
