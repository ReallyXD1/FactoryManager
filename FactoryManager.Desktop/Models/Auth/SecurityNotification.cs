using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityNotification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string Priority { get; set; }
        public List<string> Recipients { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Channel { get; set; }
    }
}
