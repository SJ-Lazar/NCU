﻿namespace Domain.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int? UserID { get; set; }
        public string? NotificationText { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }
    }


}
