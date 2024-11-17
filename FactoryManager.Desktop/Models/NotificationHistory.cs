using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationHistory
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string Channel { get; set; }
        public string Status { get; set; }
        public string DeviceInfo { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string ErrorDetails { get; set; }
        public TimeSpan ProcessingTime { get; set; }
        public string IpAddress { get; set; }
    }
}
