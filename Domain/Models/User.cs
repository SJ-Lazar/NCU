﻿namespace Domain.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } 
        public string? Email { get; set; }
        public int? RoleID { get; set; }
        public bool? IsActive { get; set; }
    }


}
