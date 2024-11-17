using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public string Source { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string ActionUrl { get; set; }
        public string Icon { get; set; }
        public bool RequiresAction { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public List<string> Tags { get; set; }
    }
}
