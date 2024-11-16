using System;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Infrastructure
{
    public interface ISignalRClient
    {
        Task StartAsync(string url);
        Task StopAsync();
        void On<T>(string methodName, Action<T> handler);
        Task JoinGroupAsync(string groupName);
        Task LeaveGroupAsync(string groupName);
    }
}
