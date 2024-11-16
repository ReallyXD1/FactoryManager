using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ISignalRClient _signalRClient;

        public NotificationService(
            IHttpClient httpClient,
            IConfiguration configuration,
            ISignalRClient signalRClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _signalRClient = signalRClient;

            InitializeSignalR();
        }

        private void InitializeSignalR()
        {
            _signalRClient.On<Notification>("ReceiveNotification", notification =>
            {
                OnNotificationReceived?.Invoke(this, notification);
            });
        }

        public event EventHandler<Notification> OnNotificationReceived;

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_configuration["ApiUrl"]}/notifications");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Notification>>();
                }
                return new List<Notification>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get notifications error: {ex.Message}");
                return new List<Notification>();
            }
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/notifications/{notificationId}/read",
                    null);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Mark as read error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendNotificationAsync(Notification notification)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/notifications",
                    notification);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Send notification error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SubscribeToNotificationsAsync(string category)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/notifications/subscribe",
                    new { category });

                if (response.IsSuccessStatusCode)
                {
                    await _signalRClient.JoinGroupAsync(category);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Subscribe error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UnsubscribeFromNotificationsAsync(string category)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/notifications/unsubscribe",
                    new { category });

                if (response.IsSuccessStatusCode)
                {
                    await _signalRClient.LeaveGroupAsync(category);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unsubscribe error: {ex.Message}");
                return false;
            }
        }

        public async Task<NotificationSettings> GetNotificationSettingsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_configuration["ApiUrl"]}/notifications/settings");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<NotificationSettings>();
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get settings error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateNotificationSettingsAsync(NotificationSettings settings)
        {
            try
            {
                var response = await _httpClient.PutAsync(
                    $"{_configuration["ApiUrl"]}/notifications/settings",
                    settings);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Update settings error: {ex.Message}");
                return false;
            }
        }
    }
}
