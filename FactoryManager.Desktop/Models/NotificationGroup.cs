using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationGroup
    {
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> NotificationIds { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }
        public int UnreadCount { get; set; }
        public DateTime LastUpdated { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> Tags { get; set; }
    }
}
