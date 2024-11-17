using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Notifications
{
    public class NotificationSettings
    {
        public bool EmailNotifications { get; set; }
        public bool PushNotifications { get; set; }
        public bool SoundEnabled { get; set; }
        public Dictionary<string, bool> NotificationTypes { get; set; }
        public List<string> EmailAddresses { get; set; }
        public string PreferredLanguage { get; set; }
        public bool WorkHoursOnly { get; set; }
        public Dictionary<string, string> Channels { get; set; }
        public int RetentionDays { get; set; }
        public Dictionary<string, string> AlertLevels { get; set; }
    }
}
