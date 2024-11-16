using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using System.Net.Http.Json;
using System.Configuration;

namespace FactoryManager.Desktop.Services
{
    public class QualityService : IQualityService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificationService;

        public QualityService(
        HttpClient httpClient,
            IConfiguration configuration,
            INotificationService notificationService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _notificationService = notificationService;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
        }

        public async Task<IEnumerable<QualityControl>> GetQualityControlsAsync()
        {
            var response = await _httpClient.GetAsync("api/quality/controls");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<QualityControl>>();
            }
            return new List<QualityControl>();
        }

        public async Task<QualityControl> GetQualityControlAsync(int controlId)
        {
            var response = await _httpClient.GetAsync($"api/quality/controls/{controlId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QualityControl>();
            }
            return null;
        }

        public async Task<QualityControl> CreateQualityControlAsync(QualityControlCreate control)
        {
            var response = await _httpClient.PostAsJsonAsync("api/quality/controls", control);
            if (response.IsSuccessStatusCode)
            {
                var createdControl = await response.Content.ReadFromJsonAsync<QualityControl>();
                _notificationService.SendNotification(new Notification
                {
                    Message = $"New quality control created: {createdControl.Id}",
                    Type = "Quality"
                });
                return createdControl;
            }
            throw new Exception("Failed to create quality control");
        }

        public async Task<bool> UpdateQualityControlAsync(QualityControl control)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/quality/controls/{control.Id}", control);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteQualityControlAsync(int controlId)
        {
            var response = await _httpClient.DeleteAsync($"api/quality/controls/{controlId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<QualityStatistics> GetQualityStatisticsAsync()
        {
            var response = await _httpClient.GetAsync("api/quality/statistics");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QualityStatistics>();
            }
            return null;
        }

        public async Task<IEnumerable<QualityParameter>> GetQualityParametersAsync()
        {
            var response = await _httpClient.GetAsync("api/quality/parameters");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<QualityParameter>>();
            }
            return new List<QualityParameter>();
        }

        public async Task<IEnumerable<NonConformity>> GetNonConformitiesAsync(int controlId)
        {
            var response = await _httpClient.GetAsync($"api/quality/controls/{controlId}/nonconformities");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<NonConformity>>();
            }
            return new List<NonConformity>();
        }

        public async Task<NonConformity> ReportNonConformityAsync(NonConformityCreate nonConformity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/quality/nonconformities", nonConformity);
            if (response.IsSuccessStatusCode)
            {
                var created = await response.Content.ReadFromJsonAsync<NonConformity>();
                _notificationService.SendNotification(new Notification
                {
                    Message = $"New quality issue reported: {created.Id}",
                    Type = "Quality",
                    Severity = "Warning"
                });
                return created;
            }
            throw new Exception("Failed to report nonconformity");
        }

        public async Task<bool> ResolveNonConformityAsync(int nonConformityId, string resolution)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/quality/nonconformities/{nonConformityId}/resolve",
                new { Resolution = resolution });
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<QualityCheckList>> GetCheckListsAsync()
        {
            var response = await _httpClient.GetAsync("api/quality/checklists");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<QualityCheckList>>();
            }
            return new List<QualityCheckList>();
        }

        public async Task<byte[]> GenerateQualityReportAsync(QualityReportOptions options)
        {
            var response = await _httpClient.PostAsJsonAsync("api/quality/reports", options);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            return null;
        }

        public async Task<IEnumerable<QualityTrend>> GetQualityTrendsAsync(QualityTrendFilter filter)
        {
            var response = await _httpClient.PostAsJsonAsync("api/quality/trends", filter);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<QualityTrend>>();
            }
            return new List<QualityTrend>();
        }

        public async Task<IEnumerable<QualityInspector>> GetInspectorsAsync()
        {
            var response = await _httpClient.GetAsync("api/quality/inspectors");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<QualityInspector>>();
            }
            return new List<QualityInspector>();
        }
    }
}
