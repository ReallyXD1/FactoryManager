using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<bool> LogoutAsync();
        Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);
        Task<bool> ValidateTokenAsync();
        Task<string> GetUserRoleAsync();
        Task<string> GetUserNameAsync();
    }
}
