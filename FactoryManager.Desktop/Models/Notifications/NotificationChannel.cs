using System;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationChannel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public List<string> SubscribedUsers { get; set; }
        public DateTime LastMessageAt { get; set; }
        public int MessageCount { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
