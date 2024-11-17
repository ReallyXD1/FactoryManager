using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationBatch
    {
        public string BatchId { get; set; }
        public List<Notification> Notifications { get; set; }
        public string Channel { get; set; }
        public DateTime ScheduledFor { get; set; }
        public string Status { get; set; }
        public int TotalCount { get; set; }
        public int SentCount { get; set; }
        public int FailedCount { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
