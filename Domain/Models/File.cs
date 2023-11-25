namespace Domain.Models
{
    public class File
    {
        public int FileID { get; set; }
        public int? TaskID { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public int? UploadedBy { get; set; }
        public DateTime? UploadedAt { get; set; }
    }


}
