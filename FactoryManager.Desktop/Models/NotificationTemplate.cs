using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string BodyTemplate { get; set; }
        public Dictionary<string, string> Placeholders { get; set; }
        public List<string> SupportedChannels { get; set; }
        public string Language { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
