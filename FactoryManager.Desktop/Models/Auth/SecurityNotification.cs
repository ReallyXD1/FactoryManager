using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityNotification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public int Severity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; }
        public bool IsRead { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Category { get; set; }
        public List<string> Recipients { get; set; }
    }
}
