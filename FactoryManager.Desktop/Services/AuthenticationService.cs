using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using System.Net.Http.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;

namespace FactoryManager.Desktop.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private User _currentUser;
        private string _token;

        public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(_token) && !IsTokenExpired();

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login",
                    new { Username = username, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    _token = result.Token;
                    _currentUser = result.User;
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Logout()
        {
            _token = null;
            _currentUser = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> ChangePasswordAsync(string currentPassword, string newPassword)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/change-password",
                    new { CurrentPassword = currentPassword, NewPassword = newPassword });
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ValidateTokenAsync()
        {
            if (string.IsNullOrEmpty(_token))
                return false;

            try
            {
                var response = await _httpClient.GetAsync("api/auth/validate");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RefreshTokenAsync()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/refresh", new { Token = _token });
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    _token = result.Token;
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserSettings> GetUserSettingsAsync()
        {
            var response = await _httpClient.GetAsync("api/auth/settings");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserSettings>();
            }
            return null;
        }

        public async Task SaveUserSettingsAsync(UserSettings settings)
        {
            await _httpClient.PostAsJsonAsync("api/auth/settings", settings);
        }

        private bool IsTokenExpired()
        {
            if (string.IsNullOrEmpty(_token))
                return true;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(_token);
            return token.ValidTo < DateTime.UtcNow;
        }
    }
}
