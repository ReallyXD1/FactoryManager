using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetNotificationsAsync();
        Task<bool> MarkAsReadAsync(int notificationId);
        Task<bool> SendNotificationAsync(Notification notification);
        Task<bool> SubscribeToNotificationsAsync(string category);
        Task<bool> UnsubscribeFromNotificationsAsync(string category);
        Task<NotificationSettings> GetNotificationSettingsAsync();
        Task<bool> UpdateNotificationSettingsAsync(NotificationSettings settings);
    }
}
