using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface INotificationService
    {
        event EventHandler<Notification> OnNotificationReceived;
        void SendNotification(Notification notification);
        Task<IEnumerable<Notification>> GetNotificationsAsync();
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync();
        Task MarkAsReadAsync(int notificationId);
        Task MarkAllAsReadAsync();
        Task ClearNotificationsAsync();
        Task<NotificationSettings> GetNotificationSettingsAsync();
        Task SaveNotificationSettingsAsync(NotificationSettings settings);
        void Subscribe(string channel);
        void Unsubscribe(string channel);
    }
}
