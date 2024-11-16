using System;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface INotificationService
    {
        event EventHandler<Notification> OnNotificationReceived;
        void SendNotification(Notification notification);
        void Configure(NotificationSettings settings);
    }
}
