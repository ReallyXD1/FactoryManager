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
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificationService;

        public ReportService(
        HttpClient httpClient,
            IConfiguration configuration,
            INotificationService notificationService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _notificationService = notificationService;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
        }

        public async Task<IEnumerable<Report>> GetReportsAsync()
        {
            var response = await _httpClient.GetAsync("api/reports");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Report>>();
            }
            return new List<Report>();
        }

        public async Task<Report> GetReportAsync(int reportId)
        {
            var response = await _httpClient.GetAsync($"api/reports/{reportId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Report>();
            }
            return null;
        }

        public async Task<ReportPreview> GetReportPreviewAsync(int reportId)
        {
            var response = await _httpClient.GetAsync($"api/reports/{reportId}/preview");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReportPreview>();
            }
            return null;
        }

        public async Task<Report> GenerateReportAsync(ReportGenerate options)
        {
            var response = await _httpClient.PostAsJsonAsync("api/reports/generate", options);
            if (response.IsSuccessStatusCode)
            {
                var report = await response.Content.ReadFromJsonAsync<Report>();
                _notificationService.SendNotification(new Notification
                {
                    Message = $"Report generated: {report.Name}",
                    Type = "Reports"
                });
                return report;
            }
            throw new Exception("Failed to generate report");
        }

        public async Task<bool> ExportReportAsync(int reportId, string format = "PDF")
        {
            var response = await _httpClient.PostAsync($"api/reports/{reportId}/export?format={format}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ShareReportAsync(int reportId, string recipientEmail)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/reports/{reportId}/share",
                new { RecipientEmail = recipientEmail });
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ReportTemplate>> GetReportTemplatesAsync()
        {
            var response = await _httpClient.GetAsync("api/reports/templates");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ReportTemplate>>();
            }
            return new List<ReportTemplate>();
        }

        public async Task<IEnumerable<ReportSchedule>> GetReportSchedulesAsync()
        {
            var response = await _httpClient.GetAsync("api/reports/schedules");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ReportSchedule>>();
            }
            return new List<ReportSchedule>();
        }

        public async Task<ReportSchedule> CreateReportScheduleAsync(ReportScheduleCreate schedule)
        {
            var response = await _httpClient.PostAsJsonAsync("api/reports/schedules", schedule);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReportSchedule>();
            }
            throw new Exception("Failed to create report schedule");
        }

        public async Task<bool> UpdateReportScheduleAsync(ReportSchedule schedule)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/reports/schedules/{schedule.Id}", schedule);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteReportScheduleAsync(int scheduleId)
        {
            var response = await _httpClient.DeleteAsync($"api/reports/schedules/{scheduleId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ReportParameter>> GetReportParametersAsync(string reportType)
        {
            var response = await _httpClient.GetAsync($"api/reports/parameters?type={reportType}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ReportParameter>>();
            }
            return new List<ReportParameter>();
        }

        public async Task<byte[]> DownloadReportAsync(int reportId)
        {
            var response = await _httpClient.GetAsync($"api/reports/{reportId}/download");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            return null;
        }

        public async Task<IEnumerable<ReportFormat>> GetAvailableFormatsAsync()
        {
            var response = await _httpClient.GetAsync("api/reports/formats");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ReportFormat>>();
            }
            return new List<ReportFormat>();
        }

        public async Task<Dictionary<string, object>> GetReportMetadataAsync(int reportId)
        {
            var response = await _httpClient.GetAsync($"api/reports/{reportId}/metadata");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            }
            return new Dictionary<string, object>();
        }
    }
}
