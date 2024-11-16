using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password);
        void Logout();
        User GetCurrentUser();
        bool IsAuthenticated { get; }
    }
}
