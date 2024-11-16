using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Infrastructure
{
    public class SignalRClient : ISignalRClient
    {
        private HubConnection _connection;

        public async Task StartAsync(string url)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            await _connection.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_connection != null)
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
                _connection = null;
            }
        }

        public void On<T>(string methodName, Action<T> handler)
        {
            _connection.On(methodName, handler);
        }

        public async Task JoinGroupAsync(string groupName)
        {
            await _connection.InvokeAsync("JoinGroup", groupName);
        }

        public async Task LeaveGroupAsync(string groupName)
        {
            await _connection.InvokeAsync("LeaveGroup", groupName);
        }
    }
}
