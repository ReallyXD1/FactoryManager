namespace FactoryManager.Desktop.Models
{
    public class NotificationSettings
    {
        public bool EnableDesktopNotifications { get; set; }
        public bool EnableEmailNotifications { get; set; }
        public bool EnableSound { get; set; }
        public string SoundFile { get; set; }
        public int DisplayDuration { get; set; }
        public string Position { get; set; }
        public Dictionary<string, bool> NotificationTypes { get; set; }
    }
}
