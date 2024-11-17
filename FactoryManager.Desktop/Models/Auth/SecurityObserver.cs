using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityObserver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ObservedEvents { get; set; }
        public Dictionary<string, object> Handlers { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public TimeSpan NotificationDelay { get; set; }
        public List<string> Subscribers { get; set; }
        public DateTime LastNotification { get; set; }
        public Dictionary<string, object> Filters { get; set; }
    }
}
