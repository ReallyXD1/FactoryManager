using System;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;

namespace FactoryManager.Desktop.Services
{
    public class NotificationService : INotificationService
    {
        private NotificationSettings _settings;

        public event EventHandler<Notification> OnNotificationReceived;

        public void Configure(NotificationSettings settings)
        {
            _settings = settings;
        }

        public void SendNotification(Notification notification)
        {
            if (_settings?.EnableDesktopNotifications == true)
            {
                OnNotificationReceived?.Invoke(this, notification);
            }

            if (_settings?.EnableEmailNotifications == true)
            {
                // Implement email notification logic
            }

            if (_settings?.EnableSound == true)
            {
                // Implement sound notification logic
            }
        }
    }
}
