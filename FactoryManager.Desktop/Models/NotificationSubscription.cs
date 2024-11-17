using System;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationSubscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ChannelId { get; set; }
        public List<string> Topics { get; set; }
        public Dictionary<string, bool> Preferences { get; set; }
        public DateTime SubscribedAt { get; set; }
        public DateTime? LastNotifiedAt { get; set; }
        public string Status { get; set; }
        public string DeviceToken { get; set; }
        public Dictionary<string, string> Filters { get; set; }
    }
}
