using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public string EventType { get; set; }
        public List<string> Recipients { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TemplateId { get; set; }
        public List<string> Channels { get; set; }
    }
}
