using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class QualityService : IQualityService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public QualityService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<QualityControl>> GetQualityControlsAsync(string status = null)
        {
            try
            {
                var url = $"{_configuration["ApiUrl"]}/quality/controls";
                if (!string.IsNullOrEmpty(status))
                    url += $"?status={status}";

                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<QualityControl>>();
                }
                return new List<QualityControl>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get quality controls error: {ex.Message}");
                return new List<QualityControl>();
            }
        }

        public async Task<bool> StartControlAsync(int controlId)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/quality/controls/{controlId}/start",
                    null);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Start control error: {ex.Message}");
                return false;
            }
        }

        // Implementacja pozostałych metod interfejsu...
    }
}
