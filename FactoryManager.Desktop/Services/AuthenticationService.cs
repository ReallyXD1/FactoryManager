using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;

namespace FactoryManager.Desktop.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private User _currentUser;

        public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl");
        }

        public bool IsAuthenticated => _currentUser != null;

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var request = new { Username = username, Password = password };
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/auth/login", request);

                if (response.IsSuccessStatusCode)
                {
                    _currentUser = await response.Content.ReadFromJsonAsync<User>();
                    var token = response.Headers.GetValues("Authorization").FirstOrDefault();
                    if (!string.IsNullOrEmpty(token))
                    {
                        _httpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
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
            _currentUser = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
