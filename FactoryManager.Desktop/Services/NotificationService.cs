using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Configuration;

namespace FactoryManager.Desktop.Services
{
    public class NotificationService : INotificationService, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly HubConnection _hubConnection;
        private readonly Dictionary<string, bool> _subscriptions;

        public event EventHandler<Notification> OnNotificationReceived;

        public NotificationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _subscriptions = new Dictionary<string, bool>();

            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{_configuration["ApiBaseUrl"]}/notificationHub")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<Notification>("ReceiveNotification", notification =>
            {
                OnNotificationReceived?.Invoke(this, notification);
            });

            InitializeHubConnection();
        }

        private async void InitializeHubConnection()
        {
            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception)
            {
                // Connection will be retried automatically
            }
        }

        public void SendNotification(Notification notification)
        {
            OnNotificationReceived?.Invoke(this, notification);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            var response = await _httpClient.GetAsync("api/notifications");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Notification>>();
            }
            return new List<Notification>();
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync()
        {
            var response = await _httpClient.GetAsync("api/notifications/unread");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Notification>>();
            }
            return new List<Notification>();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            await _httpClient.PutAsync($"api/notifications/{notificationId}/read", null);
        }

        public async Task MarkAllAsReadAsync()
        {
            await _httpClient.PutAsync("api/notifications/read-all", null);
        }

        public async Task ClearNotificationsAsync()
        {
            await _httpClient.DeleteAsync("api/notifications");
        }

        public async Task<NotificationSettings> GetNotificationSettingsAsync()
        {
            var response = await _httpClient.GetAsync("api/notifications/settings");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<NotificationSettings>();
            }
            return null;
        }

        public async Task SaveNotificationSettingsAsync(NotificationSettings settings)
        {
            await _httpClient.PostAsJsonAsync("api/notifications/settings", settings);
        }

        public void Subscribe(string channel)
        {
            if (!_subscriptions.ContainsKey(channel))
            {
                _subscriptions[channel] = true;
                _hubConnection.InvokeAsync("Subscribe", channel);
            }
        }

        public void Unsubscribe(string channel)
        {
            if (_subscriptions.ContainsKey(channel))
            {
                _subscriptions.Remove(channel);
                _hubConnection.InvokeAsync("Unsubscribe", channel);
            }
        }

        public void Dispose()
        {
            _hubConnection?.DisposeAsync();
        }
    }
}
