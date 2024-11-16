using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;

namespace FactoryManager.Desktop.Services
{
    public class QualityService : IQualityService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public QualityService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl");
        }

        public async Task<IEnumerable<QualityControl>> GetQualityControlsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/quality/controls");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<QualityControl>>();
        }

        public async Task<IEnumerable<string>> GetControlTypesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/quality/types");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
        }

        public async Task<IEnumerable<string>> GetStatusesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/quality/statuses");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
        }

        public async Task<QualityControl> CreateControlAsync(QualityControl control)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/quality/controls", control);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QualityControl>();
        }

        public async Task StartControlAsync(int controlId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/quality/controls/{controlId}/start", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CompleteControlAsync(int controlId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/quality/controls/{controlId}/complete", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<NonConformity> ReportNonConformityAsync(int controlId, NonConformity nonConformity)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"{_baseUrl}/quality/controls/{controlId}/nonconformities",
                nonConformity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<NonConformity>();
        }

        public async Task<QualityReport> GenerateReportAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/quality/report");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QualityReport>();
        }

        public async Task<QualityStatistics> GetQualityStatisticsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/quality/statistics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QualityStatistics>();
        }
    }
}
