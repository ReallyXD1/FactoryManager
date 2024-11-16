using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private string _currentToken;
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_configuration["ApiUrl"]}/auth/login",
                    new { username, password });

                if (response.IsSuccessStatusCode)
                {
                    _currentToken = await response.Content.ReadAsStringAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LogoutAsync()
        {
            _currentToken = null;
            return true;
        }

        public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_configuration["ApiUrl"]}/auth/change-password",
                    new { oldPassword, newPassword });

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Change password error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ValidateTokenAsync()
        {
            if (string.IsNullOrEmpty(_currentToken))
                return false;

            try
            {
                var response = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}/auth/validate");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetUserRoleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}/auth/role");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> GetUserNameAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}/auth/username");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
