using System;

namespace FactoryManager.Desktop.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string Source { get; set; }
        public string TargetScreen { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
