using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        User GetCurrentUser();
        Task<bool> LoginAsync(string username, string password);
        void Logout();
        Task<bool> ChangePasswordAsync(string currentPassword, string newPassword);
        Task<bool> ValidateTokenAsync();
        Task<bool> RefreshTokenAsync();
        Task<UserSettings> GetUserSettingsAsync();
        Task SaveUserSettingsAsync(UserSettings settings);
    }
}
